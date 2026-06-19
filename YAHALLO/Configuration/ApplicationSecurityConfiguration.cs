
using Castle.Core.Logging;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using YAHALLO.Application.Common.Authorization;
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
                        //RoleClaimType = "role",
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
            options.AddPolicy(Policies.Admin, policy => policy.RequireClaim("UserRole", "1"));
            options.AddPolicy(Policies.Mod, policy => policy.RequireClaim("UserRole", "2"));
            options.AddPolicy(Policies.User, policy => policy.RequireClaim("UserRole", "3"));
            options.AddPolicy(Policies.Trans, policy => policy.RequireClaim("UserRole", "4"));
            options.AddPolicy(Policies.ModOrAdmin, policy => policy.RequireAssertion(context =>
                context.User.HasClaim("UserRole", "1") ||
                context.User.HasClaim("UserRole", "2")
            ));

        }
    }
}
