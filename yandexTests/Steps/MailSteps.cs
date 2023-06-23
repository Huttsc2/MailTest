using yandexTests.MailData;
using yandexTests.Pages;
using yandexTests.LetterCreating;

namespace yandexTests.Steps
{
    public class MailSteps
    {
        private WebPages Pages { get; set; }


        public MailSteps()
        {
            Pages = new WebPages();
        }
        public void Login(User user)
        {
            Pages.MainPage.LogInButton.Click();
            EnterLoginAndPassword(user);
        }

        public void ReLogin(User user)
        {
            Pages.MainPage.LogInButton.Click();
            Pages.PassportPage.CurrentAccountButton.Click();
            Pages.PassportPage.AddAccountButton.Click();
            EnterLoginAndPassword(user);
        }

        public void EnterLoginAndPassword(User user)
        {
            Pages.PassportPage.UserNameArea.SendKey(user.Login);
            Pages.PassportPage.SubmitButton.Click();
            Pages.PassportPage.PasswordArea.SendKey(user.Password);
            Pages.PassportPage.SubmitButton.Click();
        }

        public void Logout()
        {
            Pages.Mail.UserPicButton.Click();
            Pages.Mail.ExitButton.Click();
        }

        public void SendLetter(Letter letter)
        {
            Pages.Mail.WriteLetterButton.Click();
            Pages.Mail.LetterRecipientArea.SendKey(letter.GetRecipient());
            Pages.Mail.SubjectArea.SendKey(letter.GetSubject());
            Pages.Mail.MessageArea.SendKey(letter.GetMessage());
            Pages.Mail.SendMessageButton.Click();
        }

        public string GetUserName()
        {
            Pages.MainPage.UserPicButton.Click();
            return Pages.MainPage.UserName.GetText();
        }

        public void OpenUserMailbox()
        {
            Pages.MainPage.UserPicButton.Click();
            Pages.MainPage.OpenMailButton.Click();
        }

    }
}
