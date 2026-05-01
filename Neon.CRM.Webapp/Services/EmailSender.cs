using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net.Mail;

namespace Neon.CRM.Webapp.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var formAddress = _configuration["EmailSettings:EmailAddress"];
            var stmpServer = _configuration["EmailSettings:Server"];
            var stmpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);

            var message = new MailMessage
            {
                From = new MailAddress(formAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            message.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(stmpServer, stmpPort))
            {
                await client.SendMailAsync(message);
            }
        }
    }
}
