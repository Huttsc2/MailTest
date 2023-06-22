using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yandexTests.Helpers;
using yandexTests.MailData;

namespace yandexTests.LetterCreating
{
    public class Letter
    {
        private static string Recipient { get; set; }
        private static string Subject { get; set; }
        private static string Message { get; set; }

        public Letter(User recipient)
        {
            RandomString randomString = new RandomString();
            Recipient = recipient.Email;
            Subject = randomString.GetRandomString();
            Message = randomString.GetRandomString();
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
