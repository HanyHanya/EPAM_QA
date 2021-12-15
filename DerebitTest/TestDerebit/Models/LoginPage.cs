using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models
{
    class LoginPage : Page
    {
        private By _emileFieldLocator = By.XPath("//*[@id='email']");
        private By _passwordFieldLocator = By.XPath("//*[@id='password']");
        private By _loginButtonLocator = By.XPath("//button[@data-id='login']");

        public LoginPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private LoginPage EnterEmail(String email)
        {           
            WaitUntilVisibleAndSendKeys(_emileFieldLocator, email);
            return this;
        }

        private LoginPage EnterPassword(String password)
        {
            WaitUntilVisibleAndSendKeys(_passwordFieldLocator, password);
            return this;
        }

        private MainPage Login()
        {
            WaitUntilClickableAndClick(_loginButtonLocator);
            return new MainPage(_driver);
        }

        public MainPage LoginAs(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            return Login();
        }
    }
}
