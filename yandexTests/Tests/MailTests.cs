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
            User user = new TestDataReader().GetTestUser();
            WebPages pages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps();
            string expectedLogin = user.Login2;
            string actualLogin;
            pages.MainPage.Open();
            steps.Login(user.Login2, user.Password2);
            actualLogin = steps.GetLogin();
            softAssertions.Add("login", expectedLogin, actualLogin);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            User user = new TestDataReader().GetTestUser();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            pages.MainPage.Open();
            steps.Login(user.Login1, user.Password1);
            steps.OpenMail();
            steps.SendLetter(user.Email2, subject, message);
            Browser.GetInstance().AlertAccept();
            steps.Logout();
            steps.ReLogin(user.Login2, user.Password2);
            pages.Mail.getLetterBySubject(subject).Click();
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
            User user = new TestDataReader().GetTestUser();
            RandomString randomString = new RandomString();
            WebPages pages = new WebPages();
            MailSteps steps = new MailSteps();
            SmtpHelpers smtp = new SmtpHelpers();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();

            MailMessage mailMessage = smtp.GetMailMessage(user.Email1, subject, message);
            smtp.AddRecipient(mailMessage, user.Email2);
            SmtpClient smtpClient = smtp.GetClient(user.Email1, user.Password1SMTP);
            smtp.SendLetter(smtpClient, mailMessage);

            pages.MainPage.Open();
            steps.Login(user.Login2, user.Password2);
            steps.OpenMail();
            pages.Mail.getLetterBySubject(subject).Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", message, actualMessage);
            softAssertions.Add("subject", subject, actualSubject);
            softAssertions.AssertAll();
        }
    }
}