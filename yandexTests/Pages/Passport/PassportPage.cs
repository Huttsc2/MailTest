using yandexTests.PageElement;

namespace yandexTests.Pages.Passport
{
    public class PassportPage : PageBase
    {
        public WebElement UserNameArea = new("//input[@name='login']");
        public WebElement PasswordArea = new("//input[@type='password']");
        public WebElement SubmitButton = new("//button[@type='submit']");
        public WebElement CurrentAccountButton = new("//a[contains(@class, 'CurrentAccount')]");
        public WebElement AddAccountButton = new("//span[@class='AddAccountButton-icon']");
    }
}
