using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Configuration;

public static class SecureApplicationSecurityConfiguration
{
    public static IServiceCollection ConfigureApplicationSecurity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddTransient<IJwtService, JwtService>();

        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

        var auth = configuration.GetSection("Authentication");
        var issuer = GetRequired(auth, "ValidIssuer");
        var audience = GetRequired(auth, "ValidAudience");
        var secretKey = GetRequired(auth, "SecretKey");

        if (Encoding.UTF8.GetByteCount(secretKey) < 32)
        {
            throw new InvalidOperationException("Authentication:SecretKey must be at least 32 bytes for HMAC-SHA256.");
        }

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2),
                    RoleClaimType = System.Security.Claims.ClaimTypes.Role,
                    NameClaimType = JwtRegisteredClaimNames.Sub
                };
            });

        services.AddAuthorization(ConfigureAuthorization);
        return services;
    }

    private static void ConfigureAuthorization(AuthorizationOptions options)
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();

        options.AddPolicy("Any", policy => policy.RequireRole("UserLevel", "2"));
        options.AddPolicy("Admin", policy => policy.RequireRole("UserLevel", "1"));
        options.AddPolicy("Mod", policy => policy.RequireRole("UserLevel", "4"));
    }

    private static string GetRequired(IConfiguration section, string key)
    {
        var value = section[key];
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

