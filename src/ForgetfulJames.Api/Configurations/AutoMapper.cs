using AutoMapper;
using ForgetfulJames.Business.Mappings;

namespace ForgetfulJames.Api.Configurations
{
    internal static class AutoMapper
    {
        internal static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new ToDoMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
