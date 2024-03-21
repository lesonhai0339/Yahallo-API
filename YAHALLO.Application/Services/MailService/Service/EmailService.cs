using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Models;

namespace YAHALLO.Application.Services.MailService.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigration _econfigration;
        public EmailService(EmailConfigration econfigration)
        {
            _econfigration = econfigration;
        }

        public void SendEmail(Message mess)
        {
            var emailMessage = CreateEmailMessage(mess);
            Send(emailMessage);
        }
        public void SendEmailWithCSS(Message mess)
        {
            var emailMessage = CreateEmailMessageWithCSS(mess);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(Message mess)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _econfigration.From));
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
            emailMessage.From.Add(new MailboxAddress("email", _econfigration.From));
            emailMessage.To.AddRange(mess.To);
            emailMessage.Subject = mess.Subject;
            //string htmlBody = File.ReadAllText("TemplateEmail.html");
            //htmlBody = htmlBody.Replace("{mess.Subject}", mess.Subject);
            //htmlBody = htmlBody.Replace("{mess.Content}", mess.Content);

            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = htmlBody;

            //emailMessage.Body = bodyBuilder.ToMessageBody();

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
                      <!DOCTYPE html>
                            <html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
                            <head>
                                <meta charset=""utf-8"" />
                                <title>{mess.Subject}</title>
                                <style>
                                    body{{
                                        display: flex;
                                        width: 100%;
                                        height: 100%;
                                        justify-content: center;
                                        align-items: center;
                                        margin: 0;
                                    }}
                                    .content{{
                                        display: grid;
                                        justify-content: start;
                                        align-items: center;
                                        background-color: rgb(216, 239, 239);
                                        width: 50%;
                                        height: 100%;
                                        padding: 1rem;
                                    }}
                                    .subject{{
                                        display: block;
                                        width: 100%;
                                        color: red;
                                        font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
                                        font-size: xx-large;
                                        font-weight: 700;
                                        text-shadow: 0 1px 2px;
                                    }}
                                    .content{{
                                        color: black;
                                    }}
                                </style>
                            </head>
                            <body>
                                <div class=""content"">
                                    <h3 class=""subject"">{mess.Subject}</h3>
                                    <div class=""content"">
                                        {mess.Content}
                                    </div>
                                </div>
                            </body>
                            </html>
                        ";
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
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
    }
}
