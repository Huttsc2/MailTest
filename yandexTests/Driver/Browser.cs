using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

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
            //TODO update method get chromedriver localy

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
        

        //TODO make method to find all clickable elements by xpath

        public List<IWebElement> FindClickableElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> visibleElements;
            try
            {
                visibleElements = fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return visibleElements;
        }

        public IWebElement? FindVisibleElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {
                element = fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        public List<IWebElement>? FindVivsibleElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            try
            {
                elements = fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return elements;
        }

        public IWebElement? FindHiddenElement(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement element;
            try
            {
                element = fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
            }
            catch (Exception)
            {
                return null;
            }
            return element;
        }

        public List<IWebElement>? FindHiddenElements(string xpath)
        {
            IWait<IWebDriver> fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(50),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            List<IWebElement> elements;
            try
            {
                elements = fluentWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath))).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            return elements;
        }

        public void AlertAccept()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IAlert alert;
            try
            {
                alert = wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
            } 
            catch (Exception)
            {

            }
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
