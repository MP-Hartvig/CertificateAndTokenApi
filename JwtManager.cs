using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CertificateAndTokenApi
{
    public class JwtManager
    {
        public static string JWT_PUBLIC_KEY = "TestCertificateAndJwtKomNuForHelvedeHvorMangeTegnSkalDerTil";
        private const int Token_Validity = 60;

        public static TokenModel Generate()
        {
            TokenModel Newtoken = new TokenModel();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(JWT_PUBLIC_KEY);
            DateTime tokenExpiresTime = DateTime.Now.AddMinutes(Token_Validity);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "User"));

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "https://localhost:27016",
                Issuer = "https://localhost:27016",
                Expires = tokenExpiresTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            Newtoken.token = jwtSecurityTokenHandler.WriteToken(securityToken);
            Newtoken.expiresIn = (int)tokenExpiresTime.Subtract(DateTime.Now).TotalSeconds;

            return Newtoken;
        }
    }
}
