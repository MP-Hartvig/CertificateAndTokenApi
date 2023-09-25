using CertificateAndTokenApi.DTO;

namespace CertificateAndTokenApi.Interfaces
{
    public interface ITokenService
    {
        public TokenDto CreateToken(LoginDto login);
    }
}
