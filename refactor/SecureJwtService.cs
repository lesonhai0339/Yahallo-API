using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Services;

public sealed class SecureJwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public SecureJwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(string id, List<string> roles)
    {
        return CreateToken(id, null, roles);
    }

    public string CreateToken(string id, UserLevel level, List<string> roles)
    {
        return CreateToken(id, (UserLevel?)level, roles);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    private string CreateToken(string id, UserLevel? level, IEnumerable<string> roles)
    {
        var issuer = GetRequired("ValidIssuer");
        var audience = GetRequired("ValidAudience");
        var secretKey = GetRequired("SecretKey");

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };

        if (level.HasValue)
        {
            claims.Add(new Claim("UserLevel", ((int)level.Value).ToString()));
        }

        foreach (var role in roles.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct())
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GetRequired(string key)
    {
        var value = _configuration[$"Authentication:{key}"];
        if (string.IsNullOrWhiteSpace(value))
        {
            value = Environment.GetEnvironmentVariable($"Authentication_{key}");
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Missing Authentication:{key} configuration.");
        }

        return value;
    }
}
