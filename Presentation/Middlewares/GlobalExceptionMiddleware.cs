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
				context.Response.StatusCode = 500;
				context.Response.ContentType = "application/xml";

				var errorXml = $@"
				<Error>
					<Message>{System.Security.SecurityElement.Escape(ex.Message)}</Message>
				</Error>";

				await context.Response.WriteAsync(errorXml);
			}
		}
	}
}
