using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models
{
    class LoginPage
    {
        private WebDriver _driver;
        private WebDriverWait _wait;

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
            _driver.FindElement(_emileFieldLocator).SendKeys(email);
            return this;
        }

        private LoginPage EnterPassword(String password)
        {
            _driver.FindElement(_passwordFieldLocator).SendKeys(password);
            return this;
        }

        private MainPage Login()
        {
            _driver.FindElement(_loginButtonLocator).Click();
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
