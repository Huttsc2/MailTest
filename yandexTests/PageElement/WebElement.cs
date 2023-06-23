using yandexTests.Driver;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace yandexTests.PageElement
{
    public class WebElement
    {

        private Browser Browser = Browser.GetInstance();
        private IWebElement? Element { get; set; }
        private string XPath { get; set; }
        private bool IsHidden { get; set; }
        private int TimeoutInSec = 30;
        private bool ReloadObject = true;

        public WebElement(bool isHidden, string xpath)
        {
            XPath = xpath;
            IsHidden = isHidden;
        }

        public void SetElement(IWebElement element)
        {
            Element = element;
            ReloadObject = false;
        }

        public void Click()
        {
            CheckCondition(TimeoutInSec);
            CheckNull();
            Element.Click();
        }

        public void SendKey(string data)
        {
            CheckCondition(TimeoutInSec);
            CheckNull();
            Element.SendKeys(data);
        }


        public string GetText()
        {
            CheckCondition(TimeoutInSec);
            CheckNull();
            return Element.Text;
        }

        private void CheckNull()
        {
            if (Element == null)
            {
                Assert.Fail();
            }
        }

        private void CheckCondition(int timeoutInSec)
        {
            if (!ReloadObject)
            {
                return;
            }
            if (!IsHidden)
            {
                Element = Browser.FindClickableElement(XPath, timeoutInSec);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
