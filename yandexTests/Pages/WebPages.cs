using yandexTests.Pages.Passport;
using yandexTests.Pages.Passport.Mail;


namespace yandexTests.Pages
{
    public class WebPages
    {
        public MainPage MainPage
        {
            get
            {
                MainPage page = new();
                page.SetUrl("https://360.yandex.ru/");
                return page;
            }
        }

        public PassportPage PassportPage
        {
            get
            {
                PassportPage passport = new();
                passport.SetUrl("https://passport.yandex.ru/");
                return passport;
            }
        }

        public Mail Mail
        {
            get
            {
                Mail mail = new();
                mail.SetUrl("https://mail.yandex.ru/");
                return mail;
            }
        }
    }
}
