using ForgetfulJames.Api.Configurations;
using ForgetfulJames.Api.Middleware;

namespace ForgetfulJames.Api.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static WebApplication UseForgetfulJamesServices(this WebApplication webApplication)
        {
            // Configure the HTTP request pipeline.
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }
            else if(webApplication.Environment.IsProduction())
            {
                // TODO: 
            }

            webApplication.UseAuthorization();
            webApplication.UseAuthentication();
            webApplication.UseMiddleware<JwtMiddleware>();
            webApplication.MapControllers();
            webApplication.UseSwaggerServices();
            webApplication.UseHttpsRedirection();

            return webApplication;
        }
    }
}
