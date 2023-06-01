using Auth0.AspNetCore.Authentication;

namespace ForgetfulJames.Api.Configurations
{
    internal static class AuthO
    {
        internal static IServiceCollection AddAuto0Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication().AddJwtBearer();
            services.AddAuthorization();
            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = configuration["Auth0:Domain"];
                options.ClientId = configuration["Auth0:ClientId"];
            });

            return services;
        }
    }
}
