using yandexTests.Pages;

namespace yandexTests.Steps
{
    public class MailSteps
    {
        public void Login(string login, string password)
        {
            WebPages pages = new WebPages();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(login);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(password);
            pages.PassportPage.SubmitButton.Click();
        }

        public void ReLogin(string login, string password)
        {
            WebPages pages = new WebPages();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.CurrentAccountButton.Click();
            pages.PassportPage.AddAccountButton.Click();
            pages.PassportPage.UserNameArea.SendKey(login);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(password);
            pages.PassportPage.SubmitButton.Click();
        }

        public void Logout()
        {
            WebPages pages = new WebPages();
            pages.Mail.UserPicButton.Click();
            pages.Mail.ExitButton.Click();
        }

        public void SendLetter(string recipient, string subject, string message)
        {
            WebPages pages = new WebPages(); 
            pages.Mail.WriteLetterButton.Click();
            pages.Mail.LetterRecipientArea.SendKey(recipient);
            pages.Mail.SubjectArea.SendKey(subject);
            pages.Mail.MessageArea.SendKey(message);
            pages.Mail.SendMessageButton.Click();
        }

        public string GetLogin()
        {
            WebPages pages = new WebPages();
            pages.MainPage.UserPicButton.Click();
            return pages.MainPage.UserName.GetText();
        }

        public void OpenMail()
        {
            WebPages pages = new WebPages();
            pages.MainPage.UserPicButton.Click();
            pages.MainPage.OpenMailButton.Click();
        }

    }
}
