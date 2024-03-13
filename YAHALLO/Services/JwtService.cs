using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Services
{
    public class JwtService : IJwtService
    {
        public string CreateToken(string ID, string roles)
        {
            var claims = new List<Claim>
            {

                new(JwtRegisteredClaimNames.Sub, ID),
                new(ClaimTypes.Role, roles)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YahalloMangaAPI"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                // issuer: "test",
                // audience: "api",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
