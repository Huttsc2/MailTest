using System.Net;
using System.Net.Mail;
using yandexTests.LetterCreating;
using yandexTests.MailData;

namespace yandexTests.SMTP
{
    public class SmtpHelpers
    {
        private static MailMessage? MailMessage {  get; set; }
        private static SmtpClient? SmtpClient { get; set; }
        private static Letter? Letter { get; set; }
        private static User? Sender { get; set; }
        private static User? Recipient { get; set; }

        public SmtpHelpers(Letter letter, User sender, User recipient)
        {
            SmtpClient = new SmtpClient();
            MailMessage = new MailMessage();
            Letter = letter;
            Sender = sender;
            Recipient = recipient;
        }

        public void SmtpInit()
        {
            SetMailMessage();
            SetClient();
            AddRecipient();
        }

        private void SetMailMessage()
        {
            MailMessage.From = new MailAddress(Sender.Email);
            MailMessage.Subject = Letter.GetSubject();
            MailMessage.Body = Letter.GetMessage();
            MailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        }

        private void SetClient()
        {
            SmtpClient.Port = 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Host = "smtp.yandex.ru";
            SmtpClient.Credentials = new NetworkCredential(Sender.Email, Sender.PasswordSMTP);
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        private void AddRecipient()
        {
            MailMessage.To.Add(new MailAddress(Recipient.Email));
        }

        public void AddRecipient(string email)
        {
            MailMessage.To.Add(new MailAddress(email));
        }

        public void SendLetter()
        {
            SmtpClient.Send(MailMessage);
        }
    }
}
