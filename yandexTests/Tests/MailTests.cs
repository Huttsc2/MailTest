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
            UserList userList = new UserList();
            WebPages pages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps(pages);
            User user = userList.GetUser();
            pages.MainPage.Open();
            steps.Login(user.Login, user.Password);
            softAssertions.Add("login", user.Login, steps.GetUserName());
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            UserList userList = new UserList();
            User sender = userList.GetUser();
            User recepinet = userList.GetUser();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps steps = new MailSteps(pages);
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            pages.MainPage.Open();
            steps.Login(sender.Login, sender.Password);
            steps.OpenUserMailBox();
            steps.SendLetter(recepinet.Email, subject, message);
            steps.Logout();
            Browser.GetInstance().AlertAccept();
            steps.ReLogin(recepinet.Login, recepinet.Password);
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
            UserList userList = new UserList();
            RandomString randomString = new RandomString();
            WebPages pages = new WebPages();
            MailSteps steps = new MailSteps(pages);
            SmtpHelpers smtp = new SmtpHelpers();
            User sender = userList.GetUser();
            User recepinet = userList.GetUser();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();

            MailMessage mailMessage = smtp.GetMailMessage(sender.Email, subject, message);
            smtp.AddRecipient(mailMessage, recepinet.Email);
            SmtpClient smtpClient = smtp.GetClient(sender.Email, sender.PasswordSMTP);
            smtp.SendLetter(smtpClient, mailMessage);

            pages.MainPage.Open();
            steps.Login(recepinet.Login, recepinet.Password);
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