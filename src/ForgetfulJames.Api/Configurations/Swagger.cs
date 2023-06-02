using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace ForgetfulJames.Api.Configurations
{
    internal static class Swagger
    {
        internal static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ForgetfulJames",
                    Version = "v1"
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Using the Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                };

                c.AddSecurityDefinition("bearer", securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });
            });

            // Add API Versioning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            // Add API Explorer
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.SubstituteApiVersionInUrl = true;
            });

            //services.AddEndpointsApiExplorer();

            return services;
        }

        internal static WebApplication UseSwaggerServices(this WebApplication webApplication)
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ForgetfulJames V1");
                c.DefaultModelsExpandDepth(-1);
                c.EnablePersistAuthorization();
            });

            return webApplication;
        }
    }
}
