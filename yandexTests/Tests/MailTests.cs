using yandexTests.Driver;
using yandexTests.Pages;
using yandexTests.Helpers;
using yandexTests.MailData;
using yandexTests.Steps;
using yandexTests.SMTP;
using yandexTests.LetterCreating;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace yandexTests.Tests
{
    [TestClass]
    public class MailTests
    {

        [TestInitialize]
        public void Setup()
        {
            Browser _ = Browser.GetInstance();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.GetInstance().Quit();
        }
        
        [TestMethod]
        public void LogIn()
        {
            SoftAssertions softAssertions = new SoftAssertions();
            Users users = new TestDataReader().GetTestUsers();

            new WebPages().MainPage.Open();
            new MailSteps().Login(users.Sender);

            softAssertions.Add("login", users.Sender.Login, new MailSteps().GetUserName());
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            Users users = new TestDataReader().GetTestUsers();
            Letter letter = new Letter(users.Recipient);
            SoftAssertions softAssertions = new SoftAssertions();

            new WebPages().MainPage.Open();
            new MailSteps().Login(users.Sender);
            new MailSteps().OpenUserMailbox();
            new MailSteps().SendLetter(letter);
            new MailSteps().Logout();
            Browser.GetInstance().AlertAccept();
            new MailSteps().ReLogin(users.Recipient);
            new WebPages().Mail.LetterBySubject(letter.GetSubject()).Click();

            string actualMessage = new WebPages().Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = new WebPages().Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", letter.GetMessage(), actualMessage);
            softAssertions.Add("subject", letter.GetSubject(), actualSubject);
            softAssertions.AssertAll();
        }
        
        [TestMethod]
        public void SendLetterBySMTP()
        {
            Users users = new TestDataReader().GetTestUsers();
            Letter letter = new Letter(users.Recipient);
            SoftAssertions softAssertions = new SoftAssertions();
            SmtpHelpers smtp = new SmtpHelpers(letter, users.Sender, users.Recipient);

            smtp.SmtpInit();
            smtp.SendLetter();

            new WebPages().MainPage.Open();
            new MailSteps().Login(users.Recipient);
            new MailSteps().OpenUserMailbox();
            new WebPages().Mail.LetterBySubject(letter.GetSubject()).Click();

            string actualMessage = new WebPages().Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = new WebPages().Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", letter.GetMessage(), actualMessage);
            softAssertions.Add("subject", letter.GetSubject(), actualSubject);
            softAssertions.AssertAll();
        }
    }
}