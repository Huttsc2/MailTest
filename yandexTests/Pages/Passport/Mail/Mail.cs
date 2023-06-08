using yandexTests.PageElement;

namespace yandexTests.Pages.Passport.Mail
{
    public class Mail: PageBase
    {
        public static string? Subject;
        public WebElement WriteLetterButton = new("//a[@href='#compose']");
        public WebElement LetterRecipientArea = new("//div[@id='compose-field-1']");
        public WebElement SubjectArea = new("//input[@name='subject']");
        public WebElement MessageArea = new("//div[@role='textbox']");
        public WebElement SendMessageButton = new("//button[@aria-disabled='false']");
        public WebElement UserPicButton = new("//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement ExitButton = new("//a[contains(@class, 'action_exit')]");
        public WebElementCollection LettersByRecipient = new("//span[@title='test1.levin@yandex.ru']");
        public WebElement OpenedLetterSubjectArea = new("//div[@class='Title_content_Q-Xik']");
        public WebElement OpenedLetterMessageArea = new("//div[@class='MessageBody_body_pmf3j react-message-wrapper__body']");
        public WebElement LetterBySubject = new(xpath: Subject);

        public void SetSubject(string subject)
        {
            Subject = subject;
        }
    }
}
