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
        private readonly string? _secret;
        private readonly string? _validIssuer;
        private readonly string? _validAudience;
        public JwtService(IConfiguration configuration)
        {
            DotEnv.Load();
            _configuration = configuration;
            _secret = Environment.GetEnvironmentVariable("Authentication_SecretKey");
            _validIssuer = Environment.GetEnvironmentVariable("Authentication_ValidIssuer");
            _validAudience = Environment.GetEnvironmentVariable("Authentication_ValidAudience");
        }
        public string CreateToken(string ID, List<string> roles)
        {
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
                claims.Add(new Claim("UserRole", role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(
                issuer: _validIssuer,
                audience: _validAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string CreateToken(string ID,UserLevel level, List<string> roles)
        {
            //var secret = _configuration.GetSection("Authentication:Schemes:Bearer:SecretKey").Value!;
            //var validIssuer = _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value;
            //var validAudience = _configuration.GetSection("Authentication:Schemes:Bearer:ValidAudience").Value;
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, ID),
                new Claim("UserLevel", ((int)level).ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
                claims.Add(new Claim("UserRole", role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _validIssuer,
                audience: _validAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
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
        public string HashToken(string token)
        {
            var bytes = Encoding.UTF8.GetBytes(token);
            var hashed = SHA256.HashData(bytes);
            return Convert.ToBase64String(hashed);  
        }
        public bool VerifyToken(string saveHash, string providerToken)
        {
            var computed = HashToken(providerToken);
            return CryptographicOperations.FixedTimeEquals(
                Convert.FromBase64String(saveHash),
                Convert.FromBase64String(computed)
                );
        }
    }
}
