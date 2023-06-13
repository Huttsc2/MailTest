using System.Net.Mail;
using System.Net;
using yandexTests.Data;

namespace yandexTests.Tests
{
    [TestClass]
    public class SMTPTests
    {
        [TestMethod]
        public void SMTPTest()
        {
            
            string fromMail = "test1.levin@yandex.ru";
            string fromPassword = "ufyljmqfdkbdwbkz";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "subject";
            message.To.Add(new MailAddress("test2.levin@yandex.ru"));
            message.Body = "body";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                UseDefaultCredentials = false,
                Host = "smtp.yandex.ru",
                Credentials = new NetworkCredential(fromMail, fromPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
        }
    }
}
