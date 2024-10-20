
using Azure.Core;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace FoodApp.Api.VerticalSlicing.Common
{
    public class MailSettings
    {
        public bool EnableSsl { get; set; }
        public string Mail { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
    }
    public class EmailSenderHelper
    {
        private readonly MailSettings _mailSettings;

        public EmailSenderHelper(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Mail),
                Subject = subject
            };

            message.To.Add(MailboxAddress.Parse(toEmail));

            var builder = new BodyBuilder
            {
                HtmlBody = body
            };

            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(message);
            smtp.Disconnect(true);
        }
    }
}