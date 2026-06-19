using dotenv.net;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Models;

namespace YAHALLO.Application.Services.MailService.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigration _econfigration;
        private readonly IConfiguration _configuration;
        public EmailService(EmailConfigration econfigration,
            IConfiguration configuration)
        {
            _econfigration = econfigration;
            _configuration = configuration;
        }

        public void SendEmail(Message mess)
        {
            var emailMessage = CreateEmailMessage(mess);
            Send(emailMessage);
        }

        // PHẦN 2 — Email xác thực tài khoản: build nội dung riêng rồi gọi Phần 1.
        public void SendEmailWithCSS(Message mess)
        {
            var emailMessage = CreateEmailMessageWithCSS(mess);
            Send(emailMessage);
        }

        // PHẦN 1 — Gửi email với HTML content tùy ý.
        // mess.Content được coi là HTML và gắn thẳng vào body của template.
        public void SendHtmlEmail(Message mess)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Yahallo Email Services", _econfigration.From));
            emailMessage.To.AddRange(mess.To);
            emailMessage.Subject = mess.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = WrapInTemplate(mess.Subject, mess.Content)
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            Send(emailMessage);
        }

        // PHẦN 1 (field-based) — nhận các field từ form, build HTML body an toàn rồi gửi.
        public void SendTemplatedEmail(IEnumerable<string> to, string subject, EmailContent content)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Yahallo Email Services", _econfigration.From));
            emailMessage.To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = WrapInTemplate(subject, BuildBodyFromFields(content))
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message mess)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Yahallo Email Services", _econfigration.From));
            emailMessage.To.AddRange(mess.To);
            emailMessage.Subject = mess.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mess.Content
            };
            return emailMessage;
        }

        private MimeMessage CreateEmailMessageWithCSS(Message mess)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Yahallo Email Services", _econfigration.From));
            emailMessage.To.AddRange(mess.To);
            emailMessage.Subject = mess.Subject;

            // PHẦN 2 gọi PHẦN 1: dựng nội dung xác thực -> bọc vào template.
            var bodyHtml = BuildVerificationBody(mess);
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = WrapInTemplate(mess.Subject, bodyHtml)
            };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        // ===================== PHẦN 1 =====================
        // Shell responsive (table layout + inline style), nhận HTML body tùy ý.
        // 3 phần: HEADER (brand) - BODY (bodyHtml truyền vào) - FOOTER.
        private string WrapInTemplate(string subject, string bodyHtml)
        {
            return $@"<!DOCTYPE html>
<html lang=""vi"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <title>{subject}</title>
    <style>
        /* Reset cơ bản */
        body, table, td, a {{ -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }}
        table, td {{ mso-table-lspace: 0pt; mso-table-rspace: 0pt; }}
        img {{ -ms-interpolation-mode: bicubic; border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; }}
        body {{ margin: 0 !important; padding: 0 !important; width: 100% !important; }}
        a {{ text-decoration: none; }}

        /* Responsive cho mobile */
        @media screen and (max-width: 600px) {{
            .email-container {{ width: 100% !important; margin: 0 !important; }}
            .px {{ padding-left: 24px !important; padding-right: 24px !important; }}
            .h1 {{ font-size: 22px !important; line-height: 28px !important; }}
            .btn-a {{ display: block !important; width: 100% !important; box-sizing: border-box !important; }}
        }}
    </style>
</head>
<body style=""margin:0; padding:0; background-color:#0f1117;"">
    <!-- preheader ẩn -->
    <div style=""display:none; max-height:0; overflow:hidden; opacity:0;"">{subject}</div>

    <table role=""presentation"" width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#0f1117;"">
        <tr>
            <td align=""center"" style=""padding:24px 12px;"">

                <table role=""presentation"" class=""email-container"" width=""600"" cellpadding=""0"" cellspacing=""0"" style=""width:600px; max-width:600px; background-color:#1a1d27; border-radius:12px; overflow:hidden; font-family:'Segoe UI', Roboto, Arial, sans-serif;"">

                    <!-- ===================== HEADER ===================== -->
                    <tr>
                        <td align=""center"" style=""background:linear-gradient(135deg,#ff4655 0%,#7c3aed 100%); background-color:#ff4655; padding:28px 24px;"">
                            <span style=""font-size:26px; font-weight:800; color:#ffffff; letter-spacing:1px;"">YAHALLO</span>
                            <div style=""font-size:13px; color:#ffe2e6; margin-top:4px;"">Manga &amp; Comic Reader</div>
                        </td>
                    </tr>

                    <!-- ===================== BODY (HTML truyền vào) ===================== -->
                    <tr>
                        <td class=""px"" style=""padding:36px 40px 24px 40px; font-family:'Segoe UI', Roboto, Arial, sans-serif; color:#c7cad1;"">
                            {bodyHtml}
                        </td>
                    </tr>

                    <!-- ===================== FOOTER ===================== -->
                    <tr>
                        <td class=""px"" style=""padding:24px 40px 32px 40px; border-top:1px solid #2a2e3a;"">
                            <p style=""margin:0 0 6px 0; font-size:12px; line-height:18px; color:#6b6f7b;"">Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email.</p>
                            <p style=""margin:0; font-size:12px; line-height:18px; color:#6b6f7b;"">&copy; {DateTime.UtcNow.Year} Yahallo. All rights reserved.</p>
                        </td>
                    </tr>

                </table>

            </td>
        </tr>
    </table>
</body>
</html>";
        }

        // Build HTML body từ các field nhập ở form. Mọi text đều được HTML-encode
        // để tránh injection — form chỉ nhập field, không nhập HTML thô.
        private string BuildBodyFromFields(EmailContent c)
        {
            static string Enc(string? s) => System.Net.WebUtility.HtmlEncode(s ?? string.Empty);

            var sb = new StringBuilder();

            // Heading
            sb.Append($@"<h1 class=""h1"" style=""margin:0 0 8px 0; font-size:24px; line-height:32px; color:#ffffff; font-weight:700;"">{Enc(c.Heading)}</h1>");

            // SubHeading (tùy chọn)
            if (!string.IsNullOrWhiteSpace(c.SubHeading))
            {
                sb.Append($@"<p style=""margin:0 0 20px 0; font-size:15px; line-height:22px; color:#8b8f9a;"">{Enc(c.SubHeading)}</p>");
            }

            // Banner (tùy chọn)
            if (!string.IsNullOrWhiteSpace(c.BannerImageUrl))
            {
                sb.Append($@"<img src=""{Enc(c.BannerImageUrl)}"" alt="""" width=""520"" style=""width:100%; max-width:520px; height:auto; border-radius:8px; margin:0 0 20px 0; display:block;"" />");
            }

            // Các đoạn nội dung
            foreach (var p in c.Paragraphs)
            {
                if (string.IsNullOrWhiteSpace(p)) continue;
                sb.Append($@"<p style=""margin:0 0 14px 0; font-size:15px; line-height:24px; color:#c7cad1;"">{Enc(p)}</p>");
            }

            // Nút CTA (chỉ hiện khi có cả text lẫn url)
            if (!string.IsNullOrWhiteSpace(c.ButtonText) && !string.IsNullOrWhiteSpace(c.ButtonUrl))
            {
                sb.Append($@"
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""margin:24px 0 8px 0;"">
                    <tr>
                        <td align=""center"" bgcolor=""#ff4655"" style=""border-radius:8px;"">
                            <a class=""btn-a"" href=""{Enc(c.ButtonUrl)}"" target=""_blank""
                               style=""display:inline-block; padding:14px 36px; font-size:16px; font-weight:600; color:#ffffff; background-color:#ff4655; border-radius:8px;"">
                                {Enc(c.ButtonText)}
                            </a>
                        </td>
                    </tr>
                </table>");
            }

            // Ghi chú thêm (tùy chọn)
            if (!string.IsNullOrWhiteSpace(c.FooterNote))
            {
                sb.Append($@"<p style=""margin:24px 0 0 0; font-size:13px; line-height:20px; color:#8b8f9a;"">{Enc(c.FooterNote)}</p>");
            }

            return sb.ToString();
        }

        // ===================== PHẦN 2 =====================
        // Nội dung HTML riêng cho email xác thực tài khoản (chỉ phần body).
        private string BuildVerificationBody(Message mess)
        {
            return $@"
                <h1 class=""h1"" style=""margin:0 0 16px 0; font-size:24px; line-height:32px; color:#ffffff; font-weight:700;"">{mess.Subject}</h1>
                <p style=""margin:0 0 12px 0; font-size:15px; line-height:24px; color:#c7cad1;"">{mess.Content}</p>
                <p style=""margin:0 0 28px 0; font-size:15px; line-height:24px; color:#c7cad1;"">Vui lòng nhấn nút bên dưới để xác thực email và hoàn tất đăng ký tài khoản.</p>

                <!-- Bulletproof button -->
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""margin:0 0 28px 0;"">
                    <tr>
                        <td align=""center"" bgcolor=""#ff4655"" style=""border-radius:8px;"">
                            <a class=""btn-a"" href=""{mess.Link}"" target=""_blank""
                               style=""display:inline-block; padding:14px 36px; font-size:16px; font-weight:600; color:#ffffff; background-color:#ff4655; border-radius:8px;"">
                                Xác thực email
                            </a>
                        </td>
                    </tr>
                </table>

                <p style=""margin:0 0 8px 0; font-size:13px; line-height:20px; color:#8b8f9a;"">Nếu nút không hoạt động, hãy sao chép đường link sau vào trình duyệt:</p>
                <p style=""margin:0; font-size:13px; line-height:20px; word-break:break-all;""><a href=""{mess.Link}"" target=""_blank"" style=""color:#7c9cff;"">{mess.Link}</a></p>";
        }

        private void Send(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_econfigration.StmpServer, _econfigration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_econfigration.Username, _econfigration.Password);
                client.Send(emailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
        public string GenerateEmailToken(string userId)
        {
            DotEnv.Load();
            var key = Environment.GetEnvironmentVariable("EmailConfiguration_SecretToken");
            //var key = _configuration.GetSection("EmailConfiguration:SecretToken").Value!;
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key!)))
            {
                byte[] userIdBytes = Encoding.UTF8.GetBytes(userId);
                byte[] hashBytes = hmac.ComputeHash(userIdBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        public bool VerifyEmailToken(string userId, string token)
        {
            string expectedToken = GenerateEmailToken(userId);
            return string.Equals(expectedToken, token, StringComparison.OrdinalIgnoreCase);
        }
    }
}
