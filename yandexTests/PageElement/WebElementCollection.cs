using OpenQA.Selenium;
using yandexTests.Driver;

namespace yandexTests.PageElement
{
    public class WebElementCollection
    {
        private List<IWebElement>? Elements;
        private readonly Browser Browser = Browser.GetInstance();
        private readonly string XPath;

        public WebElementCollection(string xpath)
        {
            XPath = xpath;
        }
        public List<WebElement> ConvertToListCollection()
        {
            Elements = Browser.FindVivsibleElements(XPath);
            List<WebElement> newCollectioon = new();
            foreach (IWebElement element in Elements)
            {
                WebElement newElement = new(XPath);
                newElement.SetElement(element);
                newCollectioon.Add(newElement);
            }
            return newCollectioon;
        }
    }
}
