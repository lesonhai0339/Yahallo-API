using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Models;

namespace YAHALLO.Application.Services.MailService
{
    public static class EmailConfiguration
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            DotEnv.Load();
            //var emailConfig = configuration
            //                .GetSection("EmailConfiguration")
            //                .Get<EmailConfigration>();
            var emailConfig = new EmailConfigration
            {
                From = Environment.GetEnvironmentVariable("EmailConfiguration_From")!,
                Port = 465,
                StmpServer = "smtp.gmail.com",
                Username= Environment.GetEnvironmentVariable("EmailConfiguration_Username")!,
                Password= Environment.GetEnvironmentVariable("EmailConfiguration_Password")!
            };
            {
                services.AddSingleton(emailConfig);
            }
            return services;
        }
    }
}
