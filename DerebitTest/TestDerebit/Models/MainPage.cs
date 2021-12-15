﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDerebit.Models
{
    class MainPage
    {
        private By _menuButtonLocator = By.Id("sideMenuBtn");
        private By _transferMenuButtonLocator = By.XPath("//a[@data-id='transfer']");

        private WebDriver _driver;
        private WebDriverWait _wait;

        public MainPage(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }


        private MainPage OpenMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_menuButtonLocator));
            _driver.FindElement(_menuButtonLocator).Click();
            return this;
        }

        private TransferPage SelectTransferPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_transferMenuButtonLocator));
            _driver.FindElement(_transferMenuButtonLocator).Click();
            return new TransferPage(_driver);
        }

        public TransferPage GoToTransferPage()
        {
            OpenMenu();
            return SelectTransferPage();

        }
    }
}
