using yandexTests.Driver;
using yandexTests.Pages;
using System.Net.Mail;
using yandexTests.Helpers;
using yandexTests.MailData;
using yandexTests.Steps;
using yandexTests.SMTP;

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
            List<User> users = new TestDataReader().GetTestUsers();
            WebPages pages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps(pages, users);
            pages.MainPage.Open();
            steps.Login(users[1].Login, users[1].Password);
            softAssertions.Add("login", users[1].Login, steps.GetLogin());
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            List<User> users = new TestDataReader().GetTestUsers();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps(pages, users);
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            pages.MainPage.Open();
            steps.Login(users[0].Login, users[0].Password);
            steps.OpenUserMailBox();
            steps.SendLetter(users[1].Email, subject, message);
            steps.Logout();
            Browser.GetInstance().AlertAccept();
            steps.ReLogin(users[1].Login, users[1].Password);
            pages.Mail.LetterBySubject(subject).Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", message, actualMessage);
            softAssertions.Add("subject", subject, actualSubject);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetterBySMTP()
        {
            SoftAssertions softAssertions = new SoftAssertions();
            List<User> users = new TestDataReader().GetTestUsers();
            RandomString randomString = new RandomString();
            WebPages pages = new WebPages();
            MailSteps steps = new MailSteps(pages, users);
            SmtpHelpers smtp = new SmtpHelpers();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();

            MailMessage mailMessage = smtp.GetMailMessage(users[0].Email, subject, message);
            smtp.AddRecipient(mailMessage, users[1].Email);
            SmtpClient smtpClient = smtp.GetClient(users[0].Email, users[0].PasswordSMTP);
            smtp.SendLetter(smtpClient, mailMessage);

            pages.MainPage.Open();
            steps.Login(users[1].Login, users[1].Password);
            steps.OpenUserMailBox();
            pages.Mail.LetterBySubject(subject).Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", message, actualMessage);
            softAssertions.Add("subject", subject, actualSubject);
            softAssertions.AssertAll();
        }
    }
}