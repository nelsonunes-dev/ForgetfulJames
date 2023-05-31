using ForgetfulJames.Api.Extensions;

namespace ForgetfulJames.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddForgetfulJamesServices(builder.Configuration);

            var app = builder.Build();

            app.UseForgetfulJamesServices();

            app.Run();
        }
    }
}
