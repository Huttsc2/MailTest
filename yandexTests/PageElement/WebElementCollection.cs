using OpenQA.Selenium;
using yandexTests.Driver;

namespace yandexTests.PageElement
{
    public class WebElementCollection
    {
        private readonly Browser Browser = Browser.GetInstance();
        private List<IWebElement>? Elements { get; set; }
        private string XPath { get; set; }

        private bool IsHidden { get; set; }

        public WebElementCollection(bool isHidden, string xpath)
        {
            XPath = xpath;
            IsHidden = isHidden;
        }
        public List<WebElement> ConvertToListCollection()
        {
            Elements = Browser.FindVivsibleElements(XPath);
            List<WebElement> newCollectioon = new();
            foreach (IWebElement element in Elements)
            {
                WebElement newElement = new(IsHidden, XPath);
                newElement.SetElement(element);
                newCollectioon.Add(newElement);
            }
            return newCollectioon;
        }
    }
}
