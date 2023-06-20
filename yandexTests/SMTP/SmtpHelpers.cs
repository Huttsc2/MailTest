using System.Net;
using System.Net.Mail;

namespace yandexTests.SMTP
{
    public class SmtpHelpers
    {
        public MailMessage GetMailMessage(string email, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            return mailMessage;
        }

        public SmtpClient GetClient(string email, string password)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.yandex.ru";
            client.Credentials = new NetworkCredential(email, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            return client;
        }

        public void AddRecipient(MailMessage mailMessage, string email)
        {
            mailMessage.To.Add(new MailAddress(email));
        }

        public void SendLetter(SmtpClient client, MailMessage message)
        {
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("letter was not delivered");
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
        }
    }
}
