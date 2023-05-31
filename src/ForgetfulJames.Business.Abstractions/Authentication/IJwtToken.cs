namespace ForgetfulJames.Business.Abstractions.Authentication
{
    public interface IJwtToken
    {
        Task<string> GenerateJwtTokenAsync(string id);
        Task<Guid?> ValidateJwtTokenAsync(string? token);
    }
}
