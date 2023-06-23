using yandexTests.PageElement;

namespace yandexTests.Pages
{
    public class MainPage: PageBase
    {
        public WebElement LogInButton = new(isHidden: false, "//a[@class='Button2 Button2_type_link Button2_view_default Button2_size_m']");
        public WebElement UserPicButton = new(isHidden: false, "//div[contains(@class,'_ user-account')]/img[contains(@src, 'middle')]");
        public WebElement OpenMailButton = new(isHidden: false, "//span[@class='legouser__menu-counter']");
        public WebElement UserName = new(isHidden: false, "//div[@class='user-account user-account_has-subname_yes legouser__account i-bem']");
    }
}
