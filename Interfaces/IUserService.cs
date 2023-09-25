using CertificateAndTokenApi.DTO;

namespace CertificateAndTokenApi.Interfaces
{
    public interface IUserService
    {
        public bool CheckLogin(LoginDto login);
        public bool Register(LoginDto login);
    }
}
