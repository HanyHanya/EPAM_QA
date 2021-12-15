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
        private By _amountToSpendLocator = By.XPath("//input[@class='MuiInputBase-input MuiInput-input deribit-2068 deribit-2070 MuiInputBase-inputAdornedEnd']");
        private By _agreeCheckboxLocator = By.XPath("//input[@class='deribit-171']");
        private By _SpendButtonLocator = By.XPath("//button[@class='MuiButtonBase-root MuiButton-root deribit-56 deribit-172 MuiButton-contained MuiButton-containedPrimary Mui-disabled Mui-disabled']");

        public ByCryptoPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private ByCryptoPage EnterAmountToSpend(string amount)
        {
            WaitUntilVisibleAndSendKeys(_amountToSpendLocator, amount);
            return this;
        }

        private ByCryptoPage SelectAgreeCkechbox()
        {
            WaitUntilVisibleAndClick(_agreeCheckboxLocator);
            return this;
        }

        private ByCryptoPage SendMoneyToBy()
        {
            WaitUntilClickableAndClick(_SpendButtonLocator);
            return this;
        }

        public ByCryptoPage ByCrypto(string amount)
        {
            EnterAmountToSpend(amount);
            SelectAgreeCkechbox();
            return SendMoneyToBy();
        }

    }
}
