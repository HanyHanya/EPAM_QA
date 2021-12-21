using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models
{
    class ByCryptoPage : Page
    {
        private By _amountToSpendLocator = By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div[1]/div/div[2]/div/div[1]/div/div/input");
        private By _agreeCheckboxLocator = By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div[3]/div[2]/div/div[2]/div/label/span[2]");
        private By _spendButtonLocator = By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div[3]/div[2]/div/div[2]/div/div/button");
        private By _getAmount = By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div[3]/div[1]/div/div[2]/div/div/table/tbody/tr[4]/td[2]");
        private By _balance = By.XPath("//*[@id='mainHeader']/header/div/div[8]/div/div[3]/div[1]/div/span/span[2]");

        public ByCryptoPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
                
        private ByCryptoPage SelectAgreeCkechbox()
        {
            WaitUntilVisible(_agreeCheckboxLocator).Click();
            return this;
        }

        private ByCryptoPage SendMoneyToBy()
        {
            WaitUntilClickable(_spendButtonLocator).Click();
            return this;
        }
        public ByCryptoPage EnterAmountToSpend(string amount)
        {
            WaitUntilVisible(_amountToSpendLocator).SendKeys(amount);
            return this;
        }
        public double GetSpendAmount()
        {
            WaitUntilVisible(_getAmount);
            string s = _driver.FindElement(_getAmount).Text.Split(' ')[0];
            Console.WriteLine(s);
            return Convert.ToDouble(_driver.FindElement(_getAmount).Text.Split(' ')[0].Replace('.', ','));
        }

        public double GetSpendBalance()
        {
            WaitUntilVisible(_balance);
            string s = _driver.FindElement(_balance).Text;
            Console.WriteLine(s);
            return Convert.ToDouble(_driver.FindElement(_balance).Text.Replace('.', ','));
        }
        public ByCryptoPage ByCrypto()
        {
            SelectAgreeCkechbox();
            return SendMoneyToBy();
        }

    }
}
