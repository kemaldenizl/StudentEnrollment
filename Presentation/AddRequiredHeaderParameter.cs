using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation
{
	public class AddRequiredHeaderParameter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			if (operation.Parameters == null)
				operation.Parameters = new List<OpenApiParameter>();

			operation.Parameters.Add(new OpenApiParameter
			{
				Name = "Accept",
				In = ParameterLocation.Header,
				Required = false,
				Schema = new OpenApiSchema
				{
					Type = "string",
					Default = new OpenApiString("application/xml")
				}
			});

			operation.Parameters.Add(new OpenApiParameter
			{
				Name = "Content-Type",
				In = ParameterLocation.Header,
				Required = false,
				Schema = new OpenApiSchema
				{
					Type = "string",
					Default = new OpenApiString("application/xml")
				}
			});
		}
	}
}
