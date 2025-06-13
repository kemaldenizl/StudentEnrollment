using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Xml.Schema;
using System.Xml;

namespace Presentation.Middlewares
{
	public class XsdValidationMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;
		public XsdValidationMiddleware(RequestDelegate next, ILogger<XsdValidationMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (context.Request.ContentType != null && context.Request.ContentType.Contains("application/xml"))
			{
				context.Request.EnableBuffering();
				using var reader = new StreamReader(
					context.Request.Body,
					encoding: Encoding.UTF8,
					detectEncodingFromByteOrderMarks: false,
					leaveOpen: true);

				var xmlContent = await reader.ReadToEndAsync();
				context.Request.Body.Position = 0;

				var endpoint = context.GetEndpoint();
				if (endpoint?.Metadata.GetMetadata<XsdValidationAttribute>() is XsdValidationAttribute attr)
				{
					try
					{
						ValidateXml(xmlContent, attr.XsdPath);
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "XML validation failed.");
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						await context.Response.WriteAsync($"<ErrorResponse><Message>Invalid XML: {ex.Message}</Message></ErrorResponse>");
						return;
					}
				}
			}

			await _next(context);
		}

		private void ValidateXml(string xmlContent, string xsdPath)
		{
			if (string.IsNullOrEmpty(xsdPath)) return;

			var schemas = new XmlSchemaSet();
			schemas.Add(null, xsdPath);

			var settings = new XmlReaderSettings
			{
				ValidationType = ValidationType.Schema,
				Schemas = schemas
			};

			var validationErrors = new StringBuilder();
			settings.ValidationEventHandler += (sender, args) =>
			{
				validationErrors.AppendLine(args.Message);
			};

			using var stringReader = new StringReader(xmlContent);
			using var xmlReader = XmlReader.Create(stringReader, settings);
			while (xmlReader.Read()) { }

			if (validationErrors.Length > 0)
			{
				throw new XmlSchemaValidationException($"XML validation failed: {validationErrors}");
			}
		}
	}

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
	public class XsdValidationAttribute : Attribute, IFilterMetadata
	{
		public string XsdPath { get; }

		public XsdValidationAttribute(string xsdPath)
		{
			XsdPath = xsdPath;
		}
	}

	public static class XsdValidationMiddlewareExtensions
	{
		public static IApplicationBuilder UseXsdValidation(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<XsdValidationMiddleware>();
		}
	}
}