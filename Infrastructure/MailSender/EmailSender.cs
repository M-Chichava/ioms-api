using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.MailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);

            using (var client = new SmtpClient
                (
                    _configuration["SMTP:Host"], 
                int.Parse(_configuration["SMTP:Port"])
                )
                {
                    Credentials = new NetworkCredential
                    (
                _configuration["SMTP:Username"], 
                _configuration["SMTP:Password"]
                    )
                }
            )
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}