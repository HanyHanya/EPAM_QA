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
    class MainPage : Page
    {
        private By _menuButtonLocator = By.XPath("//button[@data-id='sideMenuBtn']");
        private By _transferMenuButtonLocator = By.XPath("//a[@data-id='transfer']");        
        private By _byCryptoMenuButtonLocator = By.XPath("//a[@data-id='buyCrypto']");        

        public MainPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private MainPage OpenMenu()
        {
            WaitUntilVisibleAndClick(_menuButtonLocator);
            return this;
        }

        private TransferPage SelectTransferPage()
        {
            WaitUntilVisibleAndClick(_transferMenuButtonLocator);
            return new TransferPage(_driver);
        }

        private ByCryptoPage SelectByCryptoferPage()
        {
            WaitUntilVisibleAndClick(_byCryptoMenuButtonLocator);
            return new ByCryptoPage(_driver);
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
    }
}
