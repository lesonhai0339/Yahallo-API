
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Configuration
{
    public static class ApplicationSecurityConfiguration
    {
        public static IServiceCollection ConfigureApplicationSecurity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IJwtService, JwtService>();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddHttpContextAccessor();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration.GetSection("Security.Bearer:Authority").Get<string>(),
                        ValidAudience = configuration.GetSection("Security.Bearer:Audience").Get<string>(),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YahalloMangaAPI")),
                    };
                });

            services.AddAuthorization(ConfigureAuthorization);

            return services;
        }


        private static void ConfigureAuthorization(AuthorizationOptions options)
        {
            //Configure policies and other authorization options here. For example:
            //options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("role", "employee"));
            //options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "Admin"));
        }
    }
}
