using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDerebit.Models
{
    class TransferPage : Page
    {
        private By _transferSourceDropDownLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a source')]");
        private By _transferDestinationDropDownLocator = By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a destination')]");
        private By _transferSourceSelectedLocator = By.XPath("//li[@data-value='34074']");
        private By _transferDestinationSelectedLocator = By.XPath("//li[@data-value='34226']");
        private By _amountTotransferLocator = By.XPath("//input[@class='MuiInputBase-input']");
        private By _transferButtonLocator = By.XPath("//button[@data-id='transferBtn']");

        private By _transferBalanceLocator = By.XPath("//p[@data-id='tradingBalance']");

        public TransferPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private TransferPage SelectSource()
        {
            WaitUntilClickable(_transferSourceDropDownLocator).Click();
            WaitUntilVisible(_transferSourceSelectedLocator).Click();
            return this;
        }

        private TransferPage SelectDestination()
        {
            WaitUntilClickable(_transferDestinationDropDownLocator).Click();
            WaitUntilVisible(_transferDestinationSelectedLocator).Click();
            return this;
        }
        private TransferPage EnterAmountToTransfer(string amount)
        {
            WaitUntilVisible(_amountTotransferLocator).SendKeys(amount);
            return this;
        }

        private TransferPage MakeTransfer()
        {            
            WaitUntilClickable(_transferButtonLocator).Click();
            return this;
        }

        public double GetTransferBalance()
        {
            WaitUntilVisible(_transferBalanceLocator);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return Convert.ToDouble(_driver.FindElement(_transferBalanceLocator).Text.Split(' ')[0]);
        }

        public TransferPage MakeTransfer(string amount)
        {
            SelectSource();
            SelectDestination();
            EnterAmountToTransfer(amount);
            MakeTransfer();
            return this;
        }
    }
}
