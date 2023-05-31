using ForgetfulJames.Business.Abstractions.Authentication;

namespace ForgetfulJames.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly IJwtToken _jwtToken;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = await _jwtToken.ValidateJwtTokenAsync(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                // context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            }

            await _next(context);
        }
    }
}
