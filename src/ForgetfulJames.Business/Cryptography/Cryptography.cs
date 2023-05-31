using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using ForgetfulJames.Business.Abstractions.Cryptography;
using ForgetfulJames.Domain.Options;

namespace ForgetfulJames.Business.Cryptography
{
    public class Cryptography : ICryptography
    {
        private readonly IDataProtector _protector;

        public Cryptography(IOptions<CryptographyOptions> options, IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(options.Value.Secret);
        }

        public async Task<string> DecryptAsync(string data, CancellationToken cancellationToken)
        {
            var result = _protector.Unprotect(data);
            return await Task.FromResult(result);
        }

        public async Task<string> EncryptAsync(string data, CancellationToken cancellationToken)
        {
            var result = _protector.Protect(data);
            return await Task.FromResult(result);
        }
    }
}
