using System.Net.Http.Headers;
using yandexTests.PageElement;

namespace yandexTests.Pages.Passport.Mail
{
    public class Mail : PageBase
    {
        public WebElement WriteLetterButton = new(isHidden: false, "//a[@href='#compose']");
        public WebElement LetterRecipientArea = new(isHidden: false, "//div[@id='compose-field-1']");
        public WebElement SubjectArea = new(isHidden: false, "//input[@name='subject']");
        public WebElement MessageArea = new(isHidden: false, "//div[@role='textbox']");
        public WebElement SendMessageButton = new(isHidden: false, "//button[@aria-disabled='false']");
        public WebElement UserPicButton = new(isHidden: false, "//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement ExitButton = new(isHidden: false, "//a[contains(@class, 'action_exit')]");
        public WebElementCollection LettersByRecipient = new(isHidden: false, "//span[@title='test1.levin@yandex.ru']");
        public WebElement OpenedLetterSubjectArea = new(isHidden: false, "//div[@class='Title_content_Q-Xik']");
        public WebElement OpenedLetterMessageArea = new(isHidden: false, "//div[@class='MessageBody_body_pmf3j react-message-wrapper__body']");

        public WebElement LetterBySubject(string subject)
        {
            return new WebElement(isHidden: false, "//span[@title='" + subject + "']");
        }
    }
}
