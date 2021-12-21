using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models.Pages
{
    class DepositPage : Page
    {
        private By _depHref = By.XPath("//a[@href='http://test.deribit.com/testnet?currency=BTC']");
        private By _createDepositAddresBattonLocator = By.XPath("//button[@data-id='generateDepositAddressBtn']");
        private By _depositAdressLocator = By.XPath("//input[@class='MuiInputBase-input']");
        private By _rowDepositAdressLocator = By.XPath("//span[@ref='eCellValue']");
        //private By _expectedRowDepositAdressLocator = By.XPath("//span[contains='eCellValue']");
        //private By _expectedRowDepositAdressLocator = By.LinkText(_depositAdress);


        static private string _depositAdress;
        public DepositPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        private DepositPage CreateDepositAdress()
        {
            WaitUntilClickable(_createDepositAddresBattonLocator).Click();
            return this;
        }
        private DepositPage CopyDepositAdress()
        {
            _depositAdress = WaitUntilVisible(_depositAdressLocator).GetAttribute("value");
            return this;
        }
        private OutDepositPage GoToOutDepositPage(string amount)
        {
            GoToPage("https://legacy.test.deribit.com/testnet?currency=BTC");
            return  new OutDepositPage(_driver, _depositAdress, amount);
        }
        public string ReturnDepositAdressValue()
        {
            return _depositAdress = WaitUntilVisible(_depositAdressLocator).GetAttribute("value");
        }
        public string ReturnFirstAdressRow()
        {
            return SelectFirst(_rowDepositAdressLocator).Text;
        }
        public OutDepositPage MakeDeposit(string amount)
        {
            CreateDepositAdress();
            CopyDepositAdress();
            return GoToOutDepositPage(amount);
        }
    }
}
