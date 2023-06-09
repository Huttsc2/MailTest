using OpenQA.Selenium;
using yandexTests.Data;
using yandexTests.Driver;
using yandexTests.Pages;
using yandexTests.PageElement;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net.Mail;
using System.Net;

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

        [Ignore]
        [TestMethod]
        public void LogIn()
        {
            MailData mailData = new MailData();
            WebPages pages = new WebPages();
            string expected = mailData.login2;
            string actual;
            pages.MainPage.Open();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(mailData.login2);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(mailData.password2);
            pages.PassportPage.SubmitButton.Click();
            pages.MainPage.UserPicButton.Click();
            actual = pages.MainPage.UserName.GetText();
            Console.WriteLine(actual);
            Assert.IsTrue(expected.Equals(actual));
        }

        [Ignore]
        [TestMethod]
        public void SendLetter()
        {
            MailData mailData = new MailData();
            WebPages pages = new WebPages();
            RandomString randomString = new RandomString();
            XPathBuilder xpathBuilder = new XPathBuilder();
            string subject = randomString.GetRandomString();
            string message = randomString.GetRandomString();
            string xpathBySubject = xpathBuilder.GetXPathBySubject(subject);
            pages.MainPage.Open();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.UserNameArea.SendKey(mailData.login1);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(mailData.password1);
            pages.PassportPage.SubmitButton.Click();
            pages.MainPage.UserPicButton.Click();
            pages.MainPage.OpenMailButton.Click();
            pages.Mail.WriteLetterButton.Click();
            pages.Mail.LetterRecipientArea.SendKey(mailData.email2);
            pages.Mail.SubjectArea.SendKey(subject);
            pages.Mail.MessageArea.SendKey(message);
            pages.Mail.SendMessageButton.Click();
            Browser.GetInstance().AlertAccept();
            pages.Mail.UserPicButton.Click();
            pages.Mail.ExitButton.Click();
            pages.MainPage.LogInButton.Click();
            pages.PassportPage.CurrentAccountButton.Click();
            pages.PassportPage.AddAccountButton.Click();
            pages.PassportPage.UserNameArea.SendKey(mailData.login2);
            pages.PassportPage.SubmitButton.Click();
            pages.PassportPage.PasswordArea.SendKey(mailData.password2);
            pages.PassportPage.SubmitButton.Click();
            pages.Mail.SetSubject(xpathBySubject);
            pages.Mail.LetterBySubject.Click();
            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            Assert.IsTrue(actualMessage.Equals(message));
        }

        
    }
}