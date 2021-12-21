using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models.Pages
{
    class OutDepositPage : Page
    {
        private By _inputDepositAdressLocator = By.XPath("//input[@id='deposit_address']");
        private By _inputDepositAmountLocator = By.XPath("//input[@id='deposit_amount']");
        private By _depositBattonLocator = By.Id("deposit");


        private string _adress;
        private string _amount;
        public OutDepositPage(WebDriver driver, string adress, string amount)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _adress = adress;
            _amount = amount;
        }

        private OutDepositPage EnterDepositAdress()
        {
            WaitUntilVisible(_inputDepositAdressLocator).SendKeys(_adress);
            return this;
        }
        private OutDepositPage EnterDepositAmount()
        {
            WaitUntilVisible(_inputDepositAmountLocator).SendKeys(_amount);
            return this;
        }
        private OutDepositPage ClickDepositButton()
        {
            WaitUntilClickable(_depositBattonLocator).Click();
            return this;
        }
        public DepositPage MakeOutDeposit()
        {
            EnterDepositAdress();
            EnterDepositAmount();
            ClickDepositButton();
            GoToPage("https://test.deribit.com/account/BTC/deposit");
            return new DepositPage(_driver);
        }
    }
}
