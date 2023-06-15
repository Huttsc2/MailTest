using OpenQA.Selenium;
using yandexTests.Driver;
using yandexTests.Pages;
using yandexTests.PageElement;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
            Console.WriteLine(actual);
            Assert.IsTrue(expected.Equals(actual));
        }

        [TestMethod]
        public void SendLetter()
        {
            User user = new TestDataReader().GetTestUser();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            XPathBuilder xpathBuilder = new XPathBuilder();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            string xpathBySubject = xpathBuilder.GetXPathBySubject(subject);
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
            pages.Mail.SetSubject(xpathBySubject);
            pages.Mail.LetterBySubject.Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            Assert.IsTrue(actualMessage.Equals(message));
        }

        [TestMethod]
        public void SendLetterBySMTP()
        {
            User user = new TestDataReader().GetTestUser();
            RandomString randomString = new RandomString();
            WebPages pages = new WebPages();
            XPathBuilder xpathBuilder = new XPathBuilder();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            string xpathBySubject = xpathBuilder.GetXPathBySubject(subject);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(user.Email1);
            mailMessage.Subject = subject;
            mailMessage.To.Add(new MailAddress(user.Email2));
            mailMessage.Body = message;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient()
            {
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
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
            pages.Mail.SetSubject(xpathBySubject);
            pages.Mail.LetterBySubject.Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            Assert.IsTrue(actualMessage.Equals(message));
        }
    }
}