using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace YourNamespace.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpSection = _configuration.GetSection("Smtp");

            using (var client = new SmtpClient(smtpSection["Host"], int.Parse(smtpSection["Port"])))
            {
                client.Credentials = new NetworkCredential(smtpSection["UserName"], smtpSection["Password"]);
                client.EnableSsl = bool.Parse(smtpSection["EnableSsl"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSection["UserName"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
