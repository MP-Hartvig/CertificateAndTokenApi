using CertificateAndTokenApi.DTO;
using CertificateAndTokenApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CertificateAndTokenApi.Services
{
    public class TokenService : ITokenService
    {
        public TokenDto CreateToken(LoginDto login)
        {
            byte[] tokenKey = GetTokenKey();
            DateTime tokenExpiresTime = SetTokenExpiry();
            List<Claim> claims = new List<Claim> { GetRoleClaim(login) };
            SecurityTokenDescriptor securityTokenDescriptor = GetDescriptor(claims, tokenExpiresTime, tokenKey);
            return AssignTokenProperties(securityTokenDescriptor, tokenExpiresTime);
        }

        private byte[] GetTokenKey()
        {
            try
            {
                return Encoding.UTF8.GetBytes(GetAppSettings("JwtKey"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private DateTime SetTokenExpiry()
        {
            try
            {
                return DateTime.Now.AddMinutes(Convert.ToDouble(GetAppSettings("JwtValidityInMinutes")));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private SecurityTokenDescriptor GetDescriptor(List<Claim> claims, DateTime tokenExpiresTime, byte[] tokenKey)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = GetAppSettings("JwtUrl"),
                Issuer = GetAppSettings("JwtUrl"),
                Expires = tokenExpiresTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
        }

        private Claim GetRoleClaim(LoginDto login)
        {
            // TODO: Get role from db instead
            return new Claim(ClaimTypes.Role, "Admin");
        }

        private TokenDto AssignTokenProperties(SecurityTokenDescriptor securityTokenDescriptor, DateTime tokenExpiresTime)
        {
            TokenDto newToken = new TokenDto();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            try
            {
                newToken.TokenString = jwtSecurityTokenHandler.WriteToken(securityToken);
                newToken.ExpiresIn = (int)tokenExpiresTime.Subtract(DateTime.Now).TotalSeconds;
                return newToken;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private string GetAppSettings(string property)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            IConfigurationRoot config = builder.Build();
            return config[property]!;
        }
    }
}
