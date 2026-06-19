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
        // Gửi email với HTML content tùy ý (gắn vào body của template).
        void SendHtmlEmail(Message mess);
        // Build HTML từ các field (form) rồi gửi — an toàn, không nhúng HTML thô.
        void SendTemplatedEmail(IEnumerable<string> to, string subject, EmailContent content);
        string GenerateEmailToken(string userId);
        bool VerifyEmailToken(string userId, string token);
    }
}
