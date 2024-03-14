using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Models;

namespace YAHALLO.Application.Services.MailService.Service
{
    public interface IEmailService
    {
        void SendEmail(Message mess);
        void SendEmailWithCSS(Message mess);
    }
}
