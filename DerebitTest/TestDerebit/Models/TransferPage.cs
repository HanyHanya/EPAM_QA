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
        private By _transferCommisionFLocator = By.XPath("//p[@data-id='currentSessionProfits']");

        public TransferPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private TransferPage SelectSource()
        {
            WaitUntilClickableAndClick(_transferSourceDropDownLocator);
            WaitUntilVisibleAndClick(_transferSourceSelectedLocator);
            return this;
        }

        private TransferPage SelectDestination()
        {
            WaitUntilClickableAndClick(_transferDestinationDropDownLocator);
            WaitUntilVisibleAndClick(_transferDestinationSelectedLocator);
            return this;
        }
        private TransferPage EnterAmountToTransfer(string amount)
        {
            WaitUntilVisibleAndSendKeys(_amountTotransferLocator, amount);
            return this;
        }

        private TransferPage MakeTransfer()
        {            
            WaitUntilClickableAndClick(_transferButtonLocator);
            return this;
        }

        public double GetTransferBalance()
        {
            string s = _driver.FindElement(_transferBalanceLocator).Text.Split(' ')[0];
            Console.WriteLine(s);
            return Convert.ToDouble(_driver.FindElement(_transferBalanceLocator).Text.Split(' ')[0].Replace('.', ','));
        }

        public double GetTransferCommision()
        {
            string s = _driver.FindElement(_transferCommisionFLocator).Text.Split(' ')[0];
            Console.WriteLine(s);
            return Convert.ToDouble(_driver.FindElement(_transferCommisionFLocator).Text.Split(' ')[0].Replace('.', ','));
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
