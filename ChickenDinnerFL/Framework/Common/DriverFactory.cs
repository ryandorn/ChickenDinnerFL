using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using ChickenDinnerFL.Framework;
using NUnit.Framework;

namespace ChickenDinnerFL.Framework.Common
{
    public class DriverFactory
    {
        private static string _browser { get; set; }
        private static string _enableGrid { get; set; }
        private static string _testName { get; set; }
        
        private DriverFactory()
        {
        }

        public static void SetTestName(string testName)
        {
            _testName = testName;
        }

        public static void SetBrowser(string browser, string enableGrid)
        {
            _browser = browser;
            _enableGrid = enableGrid;
        }

        private static DriverFactory instance = new DriverFactory();

        public static DriverFactory getInstance()
        {
            return instance;
        }


        public static IWebDriver getDriver()
        {
            try
            {
             
                string _curTestName = TestContext.CurrentContext.Test.Name;
                if (!_curTestName.Contains("AdhocTestMethod"))
                    _testName = _curTestName;
            }
            catch
            {
                
            }

            if (_enableGrid.ToLower() == "true")
            {
                var URL = Framework.Constants.REMOTE_WEBDRIVER_ADDRESS;


                if (_browser == "Chrome")
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("no-andbox");
                    return new RemoteWebDriver(new Uri(URL), options);
                }

                else if (_browser == "Firefox")
                {

                    FirefoxOptions option = new FirefoxOptions();
                    ICapabilities cap = option.ToCapabilities();
                    return new RemoteWebDriver(new Uri(URL), cap);
                }
                else
                {
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    return new RemoteWebDriver(new Uri(URL), options);
                }
            }
            else
            {
                if (_browser == "Chrome")
                {
                    return GetChrome();
                }
                else if (_browser == "Firefox")
                {
                    return GetFirefox();
                }
                else
                {
                    return GetIE();
                }
            }
        }

        #region Browsers
        private static ChromeDriver GetChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            return new ChromeDriver(chromeDriverDirectory: Framework.Constants.REMOTE_WEBDRIVER_ADDRESS, options: options);
        }

        private static FirefoxDriver GetFirefox()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Framework.Constants.REMOTE_WEBDRIVER_ADDRESS, "geckodriver.exe");
            return new FirefoxDriver(service);

        }
        
        private static InternetExplorerDriver GetIE()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            return new InternetExplorerDriver(Framework.Constants.REMOTE_WEBDRIVER_ADDRESS, options);
        }

        #endregion
    }
}