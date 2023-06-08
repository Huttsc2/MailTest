using yandexTests.PageElement;

namespace yandexTests.Pages
{
    public class MainPage: PageBase
    {
        public WebElement LogInButton = new("//a[@class='Button2 Button2_type_link Button2_view_default Button2_size_m']");
        public WebElement UserPicButton = new("//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement OpenMailButton = new("//span[@class='legouser__menu-counter']");
        public WebElement UserName = new("//div[@class='user-account user-account_has-subname_yes legouser__account i-bem']");
    }
}
