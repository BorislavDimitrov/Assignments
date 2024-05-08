using System.Net;
using System.Net.Mail;

namespace DisposalAndGarbageCollection
{
    public class EmailSender
    {
        private string smtpServer = "smtp.gmail.com";
        private int port = 587;
        private bool useSsl = true;

        public async Task SendEmailAsync(string recipientEmail, string subject, string body, string gmailAddress, string appPassword)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(gmailAddress);
                mailMessage.To.Add(new MailAddress(recipientEmail));
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                mailMessage.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient(smtpServer, port))
                {
                    smtpClient.EnableSsl = useSsl;
                    smtpClient.Credentials = new NetworkCredential(gmailAddress, appPassword);
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
