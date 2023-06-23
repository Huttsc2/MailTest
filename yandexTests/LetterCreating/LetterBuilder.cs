namespace yandexTests.LetterCreating
{
    public class LetterBuilder
    {
        private Letter _letter;

        public LetterBuilder()
        {
            _letter = new Letter();
        }

        public LetterBuilder SetSubject(string subject)
        {
            _letter.Subject = subject;
            return this;
        }

        public LetterBuilder SetRecipient(string recipient)
        {
            _letter.Recipient = recipient;
            return this;
        }

        public LetterBuilder SetMessage(string message)
        {
            _letter.Message= message;
            return this;
        }

        public Letter Build()
        {
            return _letter;
        }
    }
}
