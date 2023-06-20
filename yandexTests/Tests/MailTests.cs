using yandexTests.Driver;
using yandexTests.Pages;
using System.Net.Mail;
using System.Net;
using yandexTests.Helpers;
using yandexTests.MailData;

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
            string expected = user.Login2;
            string actual;
            pages.MainPage.Open();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(user.Login2);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(user.Password2);
            pages.PassportPage.SubmitButton.Click();
            pages.MainPage.UserPicButton.Click();
            actual = pages.MainPage.UserName.GetText();
            softAssertions.Add("login", expected, actual);
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            User user = new TestDataReader().GetTestUser();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            SoftAssertions softAssertions = new SoftAssertions();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            pages.MainPage.Open();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(user.Login1);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(user.Password1);
            pages.PassportPage.SubmitButton.Click();
            pages.MainPage.UserPicButton.Click();
            pages.MainPage.OpenMailButton.Click();
            pages.Mail.WriteLetterButton.Click();
            pages.Mail.LetterRecipientArea.SendKey(user.Email2);
            pages.Mail.SubjectArea.SendKey(subject);
            pages.Mail.MessageArea.SendKey(message);
            pages.Mail.SendMessageButton.Click();
            Browser.GetInstance().AlertAccept();
            pages.Mail.UserPicButton.Click();
            pages.Mail.ExitButton.Click();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.CurrentAccountButton.Click();
            pages.PassportPage.AddAccountButton.Click();
            pages.PassportPage.UserNameArea.SendKey(user.Login2);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(user.Password2);
            pages.PassportPage.SubmitButton.Click();
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
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();

            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(user.Email1),
                Subject = subject,
                Body = message,
                BodyEncoding = System.Text.Encoding.UTF8
            };
            mailMessage.To.Add(new MailAddress(user.Email2));

            SmtpClient smtpClient = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Host = "smtp.yandex.ru",
                Credentials = new NetworkCredential(user.Email1, user.Password1SMTP),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("letter was not delivered");
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }

            pages.MainPage.Open();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(user.Login2);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(user.Password2);
            pages.PassportPage.SubmitButton.Click();
            pages.MainPage.UserPicButton.Click();
            pages.MainPage.OpenMailButton.Click();
            pages.Mail.getLetterBySubject(subject).Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", message, actualMessage);
            softAssertions.Add("subject", subject, actualSubject);
            softAssertions.AssertAll();
        }
    }
}