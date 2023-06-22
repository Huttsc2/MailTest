using yandexTests.MailData;
using yandexTests.Pages;

namespace yandexTests.Steps
{
    public class MailSteps
    {
        private WebPages Pages { get; set; }

        public MailSteps(WebPages pages, List<User> user)
        {
            Pages = pages;
        }
        public void Login(string login, string password)
        {
            Pages.MainPage.LogInButton.Click();
            EnterLoginAndPassword(login, password);
        }

        public void ReLogin(string login, string password)
        {
            Pages.MainPage.LogInButton.Click();
            Pages.PassportPage.CurrentAccountButton.Click();
            Pages.PassportPage.AddAccountButton.Click();
            EnterLoginAndPassword(login,password);
        }

        public void EnterLoginAndPassword(string login, string password)
        {
            Pages.PassportPage.UserNameArea.SendKey(login);
            Pages.PassportPage.SubmitButton.Click();
            Pages.PassportPage.PasswordArea.SendKey(password);
            Pages.PassportPage.SubmitButton.Click();
        }

        public void Logout()
        {
            Pages.Mail.UserPicButton.Click();
            Pages.Mail.ExitButton.Click();
        }

        public void SendLetter(string recipient, string subject, string message)
        {
            Pages.Mail.WriteLetterButton.Click();
            Pages.Mail.LetterRecipientArea.SendKey(recipient);
            Pages.Mail.SubjectArea.SendKey(subject);
            Pages.Mail.MessageArea.SendKey(message);
            Pages.Mail.SendMessageButton.Click();
        }

        public string GetLogin()
        {
            Pages.MainPage.UserPicButton.Click();
            return Pages.MainPage.UserName.GetText();
        }

        public void OpenUserMailBox()
        {
            Pages.MainPage.UserPicButton.Click();
            Pages.MainPage.OpenMailButton.Click();
        }

    }
}
