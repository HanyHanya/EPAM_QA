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
    abstract class Page
    {
        public WebDriver _driver;
        public WebDriverWait _wait;

        public IWebElement WaitUntilClickable (By element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return _driver.FindElement(element);
        }

        public IWebElement WaitUntilVisible(By element)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(element));
            return _driver.FindElement(element);
        }

        public IWebElement SelectFirst(By element)
        {
            return _driver.FindElements(element).First();
        }
       
        public void GoToPage(string uri)
        {
            _driver.Navigate().GoToUrl(uri);
        }
    }
}
