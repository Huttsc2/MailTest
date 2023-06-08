﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace yandexTests.Driver
{
    public class Browser
    {
        private readonly IWebDriver driver;
        private static Browser? Instance;



        private Browser()
        {
            driver = StartChromDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);
            driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 60);
        }

        private ChromeDriver StartChromDriver()
        {
            //string dir = Directory.GetCurrentDirectory();
            //Regex reg = new(".{0,}Selenium");
            ChromeOptions options = new ChromeOptions();
            //string path = reg.Match(dir).Captures.First().Value;
            //Environment.SetEnvironmentVariable("webdriver.chrome._driver", $"{path}\\chromedriver.exe");
            options.AddArgument("--disable-browsing-history");
            options.AddArgument("--incognito");
            return new ChromeDriver(options);
        }

        public static Browser GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Browser();
            }
            return Instance;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public IWebElement? FindClickableElement(string xpath, int timeoutInSecond)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {

                element = fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        /*public List<IWebElement> FindClickableElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            elements = fluentWait.Until(ExpectedConditions.)
            return elements;
        }*/

        public IWebElement FindVisibleElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return element;
        }

        public List<IWebElement> FindVivsibleElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            elements = fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            return elements;
        }

        public IWebElement FindHiddenElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            element = fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
            return element;
        }

        public List<IWebElement> FindHiddenElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            elements = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            return elements;
        }

        public void Refresh()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
        }

        public void Quit()
        {
            Instance = null;
            driver.Quit();
        }
    }
}
