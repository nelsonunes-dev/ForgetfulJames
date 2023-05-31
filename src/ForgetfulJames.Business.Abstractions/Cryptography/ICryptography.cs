namespace ForgetfulJames.Business.Abstractions.Cryptography
{
    public interface ICryptography
    {
        Task<string> EncryptAsync(string data, CancellationToken cancellationToken);
        Task<string> DecryptAsync(string data, CancellationToken cancellationToken);
    }
}
