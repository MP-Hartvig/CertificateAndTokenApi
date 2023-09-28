using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;

namespace CertificateAndTokenApi.Services
{
    public class UserService : IUserService
    {
        List<LoginDto> users = new List<LoginDto> { new LoginDto { username = "test@admin", password = "Kode123" }, new LoginDto { username = "test@user", password = "Kode123" } };

        public UserService() { }

        public bool CheckLogin(LoginDto login)
        {
            return users.Where(x => x.username == login.username && x.password == login.password).Count() > 0 ? true : false;
        }

        public bool Register(LoginDto login)
        {
            if (users.Contains(login))
            {
                return false;
            }
            else
            {
                users.Add(login);
                return true;
            }
        }
    }
}
