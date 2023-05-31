using Newtonsoft.Json;

namespace ForgetfulJames.Dto.Authentication
{
    public class AuthenticationRequestDto
    {
        [JsonProperty(nameof(UserName))]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty(nameof(Password))]
        public string Password { get; set; } = string.Empty;
    }
}
