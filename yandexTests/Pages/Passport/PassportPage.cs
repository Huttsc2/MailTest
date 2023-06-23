using yandexTests.PageElement;

namespace yandexTests.Pages.Passport
{
    public class PassportPage : PageBase
    {
        public WebElement UserNameArea = new(isHidden: false, "//input[@name='login']");
        public WebElement PasswordArea = new(isHidden: false, "//input[@type='password']");
        public WebElement SubmitButton = new(isHidden: false, "//button[@type='submit']");
        public WebElement CurrentAccountButton = new(isHidden: false, "//a[contains(@class, 'CurrentAccount')]");
        public WebElement AddAccountButton = new(isHidden: false, "//span[@class='AddAccountButton-icon']");
    }
}
