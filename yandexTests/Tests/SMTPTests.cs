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
            string fromPassword = "qxpgbbpbauntnylr";
            //string fromPassword = "an3HJ123";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "subject";
            message.To.Add(new MailAddress("test2.levin@yandex.ru"));
            message.Body = "body";

            SmtpClient smtpClient = new SmtpClient()
            {
                Port = 465,
                EnableSsl = true,
                Timeout = 20000,
                UseDefaultCredentials = false,
                Host = "smtp.yandex.ru",
                Credentials = new NetworkCredential(fromMail, fromPassword),
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
