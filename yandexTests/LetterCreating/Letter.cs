using yandexTests.Helpers;
using yandexTests.MailData;

namespace yandexTests.LetterCreating
{
    public class Letter
    {
        private string Recipient { get; set; }
        private string Subject { get; set; }
        private string Message { get; set; }

        public Letter(User recipient)
        {
            Recipient = recipient.Email;
            Subject = new RandomString().GetRandomString();
            Message = new RandomString().GetRandomString();
        }

        public string GetRecipient()
        {
            return Recipient;
        }

        public string GetSubject()
        {
            return Subject;
        }

        public string GetMessage()
        {
            return Message;
        }
    }
}
