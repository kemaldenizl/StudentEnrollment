using Core.Utilities.Exceptions;

namespace Presentation.Middlewares
{
	public class GlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				context.Response.ContentType = "application/xml";
				context.Response.StatusCode = ex switch
				{
					NotFoundException => 404,
					UnauthorizedException => 401,
					_ => 500
				};

				var errorXml = $@"
				<ErrorResponse>
					<Message>{System.Security.SecurityElement.Escape(ex.Message)}</Message>
				</ErrorResponse>";

				await context.Response.WriteAsync(errorXml);
			}
		}
	}
}
