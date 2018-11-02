using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenDinnerFL.Framework.Applications.Desktop;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ChickenDinnerFL.Tests { 


 public class SignIn
{
    ChromeDriver driver = new ChromeDriver();
    SignInPageClass Sign = new SignInPageClass();
        public By SignInScreen_EmailAddressField { get { return By.XPath("//*[@id='email-address']"); } }

        Random rnd = new Random();
        [Test()]
        public void onSignin()
    {
        driver.Navigate().GoToUrl("https://qa1.hsn.com/signin");
        driver.Manage().Window.Maximize();
        Assert.IsTrue(driver.Title.Contains("Signin"));
        sign_in_enter_email();
        sign_in_enter_password();
        sign_in_go();

        }

    public void sign_in_enter_email()
    {
        String email = "hotmomma" + rnd.Next(10000,100000);
        Sign.sign_in_enter_email(email);
    }
        public void sign_in_enter_password()
        {
            Sign.sign_in_enter_password("weakpassword");
        }
        public void sign_in_go()
        {
            Sign.sign_in_go();
        }
    }
}
    