using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChickenDinnerFL.Tests._InProgress
{
    [TestFixture()]
    public class DemoTest4
    {
        public By targetText { get { return By.XPath("//div[@class='content-intro']"); } }
        public string brandText = "We are excited to launch our new and re-invigorated Sogeti brand identity. We are in the business of ‘making technology work’ and our refreshed brand reflects the innovative thinking that we bring to bear in the solutions our clients need to create value fast.";

        [Test()]
        public void _DemoTest4()
        {

            try
            {
                ChromeDriver driver = new ChromeDriver();

                driver.Navigate().GoToUrl("https://www.sogeti.com");
                driver.Manage().Window.Maximize();
                Assert.IsTrue(driver.Title.Contains("Sogeti"));
                Thread.Sleep(3000); //don't do this, need to add the selenium wait functionality, just for demo.

                driver.FindElement(By.XPath("//div[@class='hero-header']//span")).Click();
                Assert.IsTrue(driver.Title.Contains("Meet our new Brand"));
                Thread.Sleep(3000);

                IWebElement textInTestElement = driver.FindElement(targetText);
                string testInText = textInTestElement.Text;

                Assert.IsTrue(testInText == brandText, "The text present on the brand page is not correct.");
                driver.Quit();

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}