using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ForgetfulJames.Infrastructure.Abstractions;
using ForgetfulJames.Infrastructure.Implementations;
using ForgetfulJames.Infrastructure.Helpers;

namespace ForgetfulJames.Infrastructure.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = new ConnectionStringHelper(configuration).ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient<IInitialiseDatabase, InitialiseDatabase>();
            services.AddTransient<ISeedDatabase, SeedDatabase>();

            return services;
        }
    }
}
