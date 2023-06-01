using Microsoft.Extensions.DependencyInjection;
using ForgetfulJames.Business.Abstractions.Authentication;
using ForgetfulJames.Business.Authentication;
using ForgetfulJames.Business.Abstractions.Services;
using ForgetfulJames.Business.Services;

namespace ForgetfulJames.Business.Extensions
{
    public static class BusinessServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IInitialiseInfrastructureService, InitialiseInfrastructureService>();
            services.AddTransient<IToDoService, ToDoService>();
            services.AddTransient<IJwtToken, JwtToken>();

            return services;
        }
    }
}
