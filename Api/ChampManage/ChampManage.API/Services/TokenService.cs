using ChampManage.API.Entities;
using ChampManage.API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChampManage.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
           
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("user_type", user.UserType.ToString()),
                new Claim("user_id", user.Id.ToString())
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
