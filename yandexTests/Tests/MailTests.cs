using yandexTests.Driver;
using yandexTests.Pages;
using yandexTests.Helpers;
using yandexTests.MailData;
using yandexTests.Steps;
using yandexTests.SMTP;
using yandexTests.LetterCreating;

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
            WebPages pages = new WebPages();
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps step = new MailSteps(pages);
            User user = new UserList().GetNewTestUser();

            pages.MainPage.Open();
            step.Login(user);

            softAssertions.Add("login", user.Login, step.GetUserName());
            softAssertions.AssertAll();
        }

        [TestMethod]
        public void SendLetter()
        {
            UserList userList = new UserList();
            User sender = userList.GetNewTestUser();
            User recepinet = userList.GetNewTestUser();
            WebPages pages = new WebPages();
            Letter letter = new Letter(recepinet);
            SoftAssertions softAssertions = new SoftAssertions();
            MailSteps step = new MailSteps(pages);

            pages.MainPage.Open();
            step.Login(sender);
            step.OpenUserMailbox();
            step.SendLetter(letter);
            step.Logout();
            Browser.GetInstance().AlertAccept();
            step.ReLogin(recepinet);
            pages.Mail.LetterBySubject(letter.GetSubject()).Click();

            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", letter.GetMessage(), actualMessage);
            softAssertions.Add("subject", letter.GetSubject(), actualSubject);
            softAssertions.AssertAll();
        }
        
        [TestMethod]
        public void SendLetterBySMTP()
        {
            SoftAssertions softAssertions = new SoftAssertions();
            UserList userList = new UserList();
            User sender = userList.GetNewTestUser();
            User recepinet = userList.GetNewTestUser();
            WebPages pages = new WebPages();
            MailSteps steps = new MailSteps(pages);
            Letter letter = new Letter(recepinet);
            SmtpHelpers smtp = new SmtpHelpers(letter, sender, recepinet);

            smtp.SmtpInit();
            try
            {
                smtp.SendLetter();
            }
            catch (Exception ex)
            {
                Console.WriteLine("letter was not delivered");
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
            pages.MainPage.Open();
            steps.Login(recepinet);
            steps.OpenUserMailbox();
            pages.Mail.LetterBySubject(letter.GetSubject()).Click();

            string actualMessage = pages.Mail.OpenedLetterMessageArea.GetText();
            string actualSubject = pages.Mail.OpenedLetterSubjectArea.GetText();
            softAssertions.Add("message", letter.GetMessage(), actualMessage);
            softAssertions.Add("subject", letter.GetSubject(), actualSubject);
            softAssertions.AssertAll();
        }
    }
}