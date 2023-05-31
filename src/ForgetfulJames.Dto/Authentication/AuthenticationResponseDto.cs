using ForgetfulJames.Domain.Enums;
using Newtonsoft.Json;

namespace ForgetfulJames.Dto.Authentication
{
    public class AuthenticationResponseDto
    {
        public AuthenticationResponseDto() { }

        public AuthenticationResponseDto(string id, string token)
        {
            Id = id;
            Token = token;
        }

        [JsonProperty(nameof(Id))]
        public string? Id { get; set; }

        [JsonProperty(nameof(Status))]
        public AuthenticationStatus Status { get; set; } = AuthenticationStatus.Failed;

        [JsonProperty(nameof(Token))]
        public string? Token { get; set; }
    }
}
