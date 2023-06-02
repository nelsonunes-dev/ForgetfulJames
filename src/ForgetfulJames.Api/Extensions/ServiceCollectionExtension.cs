using ForgetfulJames.Api.Configurations;
using ForgetfulJames.Domain.Options;
using ForgetfulJames.Business.Extensions;
using ForgetfulJames.Data.Extensions;
using ForgetfulJames.Infrastructure.Extensions;

namespace ForgetfulJames.Api.Extensions
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddForgetfulJamesServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                    .AddNewtonsoftJson()
                    .AddXmlSerializerFormatters();

            services.AddAuto0Services(configuration);
            services.AddAutoMapperServices();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:7092")
                            .AllowAnyOrigin()
                            .AllowAnyMethod();
                });
            });

            services.AddHttpContextAccessor();
            
            services.AddLogging();

            services.AddSwaggerServices();

            services.Configure<Auth0Options>(configuration.GetSection("Auth0"));
            services.Configure<ConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
            services.Configure<CryptographyOptions>(configuration.GetSection("Cryptography"));
            services.Configure<InfrastructureOptions>(configuration.GetSection("Infrastructure"));
            services.Configure<JwtTokenOptions>(configuration.GetSection("JwtToken"));


            services.AddInfrastructureServices(configuration);
            services.AddDataServices();
            services.AddBusinessServices();

            return services;
        }
    }
}
