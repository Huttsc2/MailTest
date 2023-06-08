using yandexTests.Driver;

namespace yandexTests.Pages
{
    public abstract class PageBase
    {
        protected Browser _driver = Browser.GetInstance();
        protected string Url { get; set; }
        public void Open()
        {
            _driver.GoToUrl(Url);
        }

        public void SetUrl(string url)
        {
            Url = url;
        }

        public string GetUrl()
        {
            return Url;
        }

        public void Refresh()
        {
            _driver.Refresh();
        }
    }
}
