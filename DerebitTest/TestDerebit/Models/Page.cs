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

        public void WaitUntilClickableAndClick (By element)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            _driver.FindElement(element).Click();
        }

        public void WaitUntilVisibleAndClick(By element)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(element));
            _driver.FindElement(element).Click();
        }

        public void WaitUntilVisibleAndSendKeys(By element, string keys)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(element));
            _driver.FindElement(element).SendKeys(keys);
        }
    }
}
