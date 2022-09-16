using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace MinecraftServerWeb.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            #if DEBUG
                return Task.CompletedTask;
            #else
            var credentialsEmail = _configuration.GetValue<string>("EmailProvider:Email");
            var credentialsPassword = _configuration.GetValue<string>("EmailProvider:Password");
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(credentialsEmail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage};

            using (var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(credentialsEmail, credentialsPassword);
                client.Send(message);
                client.Disconnect(true);
            }

            return Task.CompletedTask;

            #endif
        }
    }
}
