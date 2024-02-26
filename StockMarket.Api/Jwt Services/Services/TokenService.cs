using Microsoft.IdentityModel.Tokens;
using StockMarket.Api.Jwt_Services.ServiceInterface;
using StockMarket.Models.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockMarket.Api.Jwt_Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        }
        public string CreateToken(ApplicationUser applicationUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email , applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName , applicationUser.UserName)

            };

            var credeitntials = new SigningCredentials(_symmetricSecurityKey , SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credeitntials,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
            
        }
    }
}
