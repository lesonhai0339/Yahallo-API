
using Castle.Core.Logging;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
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
            DotEnv.Load();
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
                        ValidIssuer = Environment.GetEnvironmentVariable("Authentication_ValidIssuer"),
                        ValidAudience = Environment.GetEnvironmentVariable("Authentication_ValidAudience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Authentication_SecretKey")!))
                        //ValidIssuer = configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value,
                        //ValidAudience = configuration.GetSection("Authentication:Schemes:Bearer:ValidAudience").Value,
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Authentication:Schemes:Bearer:SecretKey").Value!)),
                    };
                });

            services.AddAuthorization(ConfigureAuthorization);

            return services;
        }


        private static void ConfigureAuthorization(AuthorizationOptions options)
        {
            //Configure policies and other authorization options here. For example:
            options.AddPolicy("Admin", policy => policy.RequireClaim("UserLevel", "1"));
            options.AddPolicy("Mod", policy => policy.RequireClaim("UserLevel", "4"));
            options.AddPolicy("Any", policy => policy.RequireClaim("UserLevel", "2"));
            options.AddPolicy("ModOrAdmin", policy => policy.RequireAssertion(context =>
                context.User.HasClaim("UserLevel", "1") ||
                context.User.HasClaim("UserLevel", "4")
            ));

        }
    }
}
