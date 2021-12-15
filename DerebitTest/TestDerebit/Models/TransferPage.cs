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
    class TransferPage
    {
        private By _transferSourceDropDownLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a source')]");
        private By _transferDestinationDropDownLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a destination')]");
        private By _transferSourceSelectedLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Kiroki')]");
        private By _transferDestinationSelectedLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Kiroki_1')]");
        private By _amountTotransferLocator = By.XPath("//input[@class='MuiInputBase-input']");
        private By _transferButtonLocator = By.XPath("//button[@data-id='transferBtn']");

        private By _transferBalanceLocator = By.XPath("//p[@data-id='tradingBalance']");
        private By _transferCommisionFLocator = By.XPath("//p[@data-id='currentSessionProfits']");

        public double balanceBeforeTransfer { get; private set; }
        public double balanceAfterTransfer { get; private set; }
        public double transferCommision { get; private set; }

        private WebDriver _driver;
        private WebDriverWait _wait;

        public TransferPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private TransferPage SelectSource()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_transferSourceDropDownLocator));
            _driver.FindElement(_transferSourceDropDownLocator).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(_transferSourceSelectedLocator));
            _driver.FindElement(_transferSourceSelectedLocator).Click();
            return this;
        }

        private TransferPage SelectDestination()
        {
            _driver.FindElement(_transferDestinationDropDownLocator).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(_transferDestinationSelectedLocator));
            _driver.FindElement(_transferDestinationSelectedLocator).Click();
            return this;
        }
        private TransferPage EnterAmount(string amount)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_amountTotransferLocator));
            _driver.FindElement(_amountTotransferLocator).SendKeys(amount);
            return this;
        }

        private TransferPage MakeTransfer()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_transferButtonLocator));
            balanceBeforeTransfer = Convert.ToDouble(_driver.FindElement(_transferBalanceLocator).Text.Split(' ')[0]);
            transferCommision = Convert.ToDouble(_driver.FindElement(_transferCommisionFLocator).Text.Split(' ')[0]);
            _driver.FindElement(_transferButtonLocator).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(_transferBalanceLocator));
            balanceAfterTransfer = Convert.ToDouble(_driver.FindElement(_transferBalanceLocator).Text.Split(' ')[0]);
            return this;
        }

        private TransferPage MakeTransfer(string amount)
        {
            SelectSource();
            SelectDestination();
            EnterAmount(amount);
            MakeTransfer();
            return this;
        }
    }
}
