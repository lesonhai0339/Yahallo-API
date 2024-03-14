using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(string ID, string roles)
        {
            var secret = _configuration.GetSection("Authentication:Schemes:Bearer:SecretKey").Value!;
            var validIssuer = _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value;
            var validAudience = _configuration.GetSection("Authentication:Schemes:Bearer:ValidAudience").Value;
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, ID),
                new(ClaimTypes.Role, roles)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
