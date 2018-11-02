using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using ChickenDinnerFL.Framework.Common;
using ChickenDinnerFL.Tests;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ChickenDinnerFL.Framework.Applications.Desktop
{
    public class SignInPageClass
    {

        public By SignInScreen_EmailAddressField { get { return By.XPath("//*[@id='email-address']"); } }
        private By SignInScreen_PasswordField {get {return By.Id("password"); } }
        private By AccountSignIn_SignInButton { get { return By.XPath("//*[@id='signin']"); } }
        //public SignInPage(IWebDriver driver) : base(driver) { }

        public IWebDriver driver = DriverFactory.getDriver();


        public void sign_in_enter_email(string email)
        {
                Thread.Sleep(3000);
                IWebElement textInTestElement = driver.FindElement(SignInScreen_EmailAddressField);
                textInTestElement.SendKeys(email);
            
        }
        public void sign_in_enter_password(string password)
        {
            try
            {
                Thread.Sleep(3000);
                driver.FindElement(SignInScreen_PasswordField).SendKeys(password);
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void sign_in_go()
        {
            try
            {
                Thread.Sleep(3000);
                var d = driver.FindElement(AccountSignIn_SignInButton);
                d.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}