using System.Net;
using System.Net.Mail;


namespace TournaManagementServices

{

    public class MailTrap
    {
        private readonly SmtpClient _smtpClient;

        public MailTrap()
        {
            _smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("ddbb0751c0d634", "95bbd360d01848"),
                EnableSsl = true
            }; 
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var mailMessage = new MailMessage("enzomendoza8teen@gmail.com", toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            _smtpClient.Send(mailMessage);
            Console.WriteLine("Email sent to: " + toEmail);
        }
    }
}