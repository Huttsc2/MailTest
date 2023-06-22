using OpenQA.Selenium;
using yandexTests.Driver;

namespace yandexTests.PageElement
{
    public class WebElementCollection
    {
        private readonly Browser Browser = Browser.GetInstance();
        private List<IWebElement>? Elements { get; set; }
        private string XPath { get; set; }

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
