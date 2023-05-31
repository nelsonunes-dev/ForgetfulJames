using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ForgetfulJames.Business.Abstractions.Authentication;
using ForgetfulJames.Domain.Options;

namespace ForgetfulJames.Business.Authentication
{
    public class JwtToken : IJwtToken
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        public JwtToken(IOptions<JwtTokenOptions> jwtTokenOptions) 
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        /// <summary>
        /// Generates a JWT Token for authentication.
        /// </summary>
        /// <param name="user">User to authenticate.</param>
        /// <param name="options">Settings found in appsettings.json</param>
        /// <returns>Jwt Token</returns>
        public async Task<string> GenerateJwtTokenAsync(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
                Expires = DateTime.UtcNow.AddDays(_jwtTokenOptions.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

        public async Task<Guid?> ValidateJwtTokenAsync(string? token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenOptions.Secret!);
            try
            {
                var validatedToken = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                });

                var jwtToken = (JwtSecurityToken)validatedToken.SecurityToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
