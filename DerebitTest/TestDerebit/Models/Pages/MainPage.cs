using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDerebit.Models.Pages;

namespace TestDerebit.Models
{
    class MainPage : Page
    {
        private By _menuButtonLocator = By.XPath("//button[@data-id='sideMenuBtn']");
        private By _transferMenuButtonLocator = By.XPath("//a[@data-id='transfer']");        
        private By _byCryptoMenuButtonLocator = By.XPath("//a[@data-id='buyCrypto']");        
        private By _depositenuButtonLocator = By.XPath("//a[@data-id='deposit']");        

        public MainPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private MainPage OpenMenu()
        {
            WaitUntilVisible(_menuButtonLocator).Click();
            return this;
        }

        private TransferPage SelectTransferPage()
        {
            WaitUntilVisible(_transferMenuButtonLocator).Click();
            return new TransferPage(_driver);
        }

        private ByCryptoPage SelectByCryptoferPage()
        {
            WaitUntilVisible(_byCryptoMenuButtonLocator).Click();
            return new ByCryptoPage(_driver);
        }
        private DepositPage SelectDepositPage()
        {
            WaitUntilVisible(_depositenuButtonLocator).Click();
            return new DepositPage(_driver);
        }

        public TransferPage GoToTransferPage()
        {
            OpenMenu();
            return SelectTransferPage();
        }

        public ByCryptoPage GoToByCryptoPage()
        {
            OpenMenu();
            return SelectByCryptoferPage();
        }
        public DepositPage GoToDepositPage()
        {
            OpenMenu();
            return SelectDepositPage();
        }
    }
}
