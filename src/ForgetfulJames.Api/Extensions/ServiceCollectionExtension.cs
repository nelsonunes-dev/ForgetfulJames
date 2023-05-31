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

            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options => { options.SaveToken = true; });
            
            services.AddAuthorization();
            
            services.AddAutoMapperServices();

            services.AddCors();
            
            services.AddHttpContextAccessor();
            
            services.AddLogging();

            services.AddSwaggerServices();

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
