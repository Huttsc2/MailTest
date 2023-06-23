using System.Net;
using System.Net.Mail;
using yandexTests.Helpers;
using yandexTests.LetterCreating;
using yandexTests.MailData;

namespace yandexTests.SMTP
{
    public class SmtpHelpers
    {
        private MailMessage MailMessage {  get; set; }
        private SmtpClient SmtpClient { get; set; }
        private Letter Letter { get; set; }
        private User Sender { get; set; }
        private User Recipient { get; set; }

        public SmtpHelpers
            (
            Letter letter, 
            User sender, 
            User recipient
            )
        {
            SmtpClient = new SmtpClientDataReader().GetSmtpClient();
            MailMessage = new MailMessage();
            Letter = letter;
            Sender = sender;
            Recipient = recipient;
        }

        public void SmtpInit()
        {
            SetMailMessage();
            SetCredentials();
            AddRecipient();
        }

        private void SetMailMessage()
        {
            MailMessage.From = new MailAddress(Sender.Email);
            MailMessage.Subject = Letter.GetSubject();
            MailMessage.Body = Letter.GetMessage();
        }

        private void SetCredentials()
        {
            SmtpClient.Credentials = new NetworkCredential(Sender.Email, Sender.PasswordSMTP);
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
