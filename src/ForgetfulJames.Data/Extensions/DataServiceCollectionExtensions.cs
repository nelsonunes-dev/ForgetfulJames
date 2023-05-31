using Microsoft.Extensions.DependencyInjection;

namespace ForgetfulJames.Data.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
