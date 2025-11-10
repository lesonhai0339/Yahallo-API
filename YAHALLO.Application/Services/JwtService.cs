using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(string ID, List<string> roles)
        {
            DotEnv.Load();
            var secret = Environment.GetEnvironmentVariable("Authentication_SecretKey");
            var validIssuer = Environment.GetEnvironmentVariable("Authentication_ValidIssuer");
            var validAudience = Environment.GetEnvironmentVariable("Authentication_ValidAudience");
            //var secret = _configuration.GetSection("Authentication:Schemes:Bearer:SecretKey").Value!;
            //var validIssuer = _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value;
            //var validAudience = _configuration.GetSection("Authentication:Schemes:Bearer:ValidAudience").Value;
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, ID),
                //new(ClaimTypes.Role, roles)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string CreateToken(string ID,UserLevel level, List<string> roles)
        {
            DotEnv.Load();
            var secret = Environment.GetEnvironmentVariable("Authentication_SecretKey");
            var validIssuer = Environment.GetEnvironmentVariable("Authentication_ValidIssuer");
            var validAudience = Environment.GetEnvironmentVariable("Authentication_ValidAudience");
            //var secret = _configuration.GetSection("Authentication:Schemes:Bearer:SecretKey").Value!;
            //var validIssuer = _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value;
            //var validAudience = _configuration.GetSection("Authentication:Schemes:Bearer:ValidAudience").Value;
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, ID),
                //new Claim("UserLevel", level.ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));
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
