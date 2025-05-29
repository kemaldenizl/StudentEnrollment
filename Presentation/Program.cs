
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.TokenEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Middlewares;

namespace Presentation
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			var MyAllowSpecificOrigins = "AllowFrontend";

			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
					policy =>
					{
						policy.WithOrigins("http://localhost:3000")
							.AllowAnyHeader()
							.AllowAnyMethod()
							.AllowCredentials();
					});
			});

			var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,

						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
					};
					options.Events = new JwtBearerEvents
					{
						OnMessageReceived = context =>
						{
							context.Request.Cookies.TryGetValue("access_token", out var accessToken);
							if (!string.IsNullOrEmpty(accessToken))
							{
								context.Token = accessToken;
							}
							return Task.CompletedTask;
						}
					};
				});

			builder.Services.AddControllers().AddXmlSerializerFormatters();

			builder.Services.Configure<MvcOptions>(options =>
			{
				options.InputFormatters.Clear();
				options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
			});

			builder.Services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;

				options.InvalidModelStateResponseFactory = context =>
				{
					var errorMessages = context.ModelState
						.Where(e => e.Value.Errors.Count > 0)
						.SelectMany(e => e.Value.Errors.Select(err => err.ErrorMessage))
						.ToList();

					var combinedError = string.Join(" | ", errorMessages);

					var xml = $@"
					<ErrorResponse>
						<Message>{System.Security.SecurityElement.Escape(combinedError)}</Message>
					</ErrorResponse>";

					return new ContentResult
					{
						Content = xml,
						ContentType = "application/xml",
						StatusCode = 400
					};
				};
			});

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentEnrollment API", Version = "v1" });
				c.SupportNonNullableReferenceTypes();
				c.OperationFilter<AddRequiredHeaderParameter>();

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Use token with Bearer. Example: Bearer eyJhbGciOiJIUzI1..."
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
			});

			builder.Host
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>(builder =>
				{
					builder.RegisterModule(new AutofacBusinessModule());
				});

			var app = builder.Build();

			//app.UseMiddleware<GlobalExceptionMiddleware>();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			//app.UseHttpsRedirection();


			app.UseCors(MyAllowSpecificOrigins);

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
