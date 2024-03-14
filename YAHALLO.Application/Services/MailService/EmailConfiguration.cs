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
            var emailConfig = configuration
                            .GetSection("EmailConfiguration")
                            .Get<EmailConfigration>();
            if (emailConfig != null)
            {
                services.AddSingleton(emailConfig);
            }
            return services;
        }
    }
}
