using ForgetfulJames.Data.Abstractions.Common;
using ForgetfulJames.Data.Abstractions.Repositories;
using ForgetfulJames.Data.Common;
using ForgetfulJames.Data.Repositories;
using ForgetfulJames.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ForgetfulJames.Data.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<ILoggerFactory, LoggerFactory>();
            services.AddTransient<ILogger<ToDo>, Logger<ToDo>>();

            services.AddTransient<IRepository<ToDo>, Repository<ToDo>>();
            services.AddTransient<IToDoRepository, ToDoRepository>();

            return services;
        }
    }
}
