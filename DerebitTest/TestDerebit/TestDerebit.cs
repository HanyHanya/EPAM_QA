using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestDerebit.Models;
using TestDerebit.Driver;
using TestDerebit.Models.Pages;
using TestDerebit.Utilities.Logger;

namespace TestDerebit
{
    [TestFixture]
    class TestDerebit : Logging
    {
        private string username = "kiroki2001@gmail.com";
        private string password = "7mjX5@gPA23YMYc";
        private string webSiteURL = $"https://test.deribit.com/";
        private LoginPage loginPage;
        private MainPage mainPage;
        private WebDriver driver;

        public double balanceBeforeTransfer;
        public double balanceAfterTransfer;
        public double balanceBeforeByCrypto;
        public double balanceAfterByCrypto;
        public double byCryptoGetAmount;
        

        [SetUp]
        public void SetUp()
        {
            driver = Driver.Driver.GetDriver();
            driver.Navigate().GoToUrl(webSiteURL);
            loginPage = new LoginPage(driver);
            mainPage = loginPage.LoginAs(username, password);
        }
        [Test]
        [TestCase(1)]
        public void Transfer_returnExpectedValue(double TransferAmount)
        {

            TransferPage transferPage = mainPage.GoToTransferPage();
            balanceBeforeTransfer = transferPage.GetTransferBalance();
            transferPage.MakeTransfer(Convert.ToString(TransferAmount));
            balanceAfterTransfer = transferPage.GetTransferBalance();
            double expected = balanceBeforeTransfer - TransferAmount;
            double real = balanceAfterTransfer;
            Assert.AreEqual(expected, real);
        }

        [Test]
        [TestCase(1000)]
        public void ByCrypto_ReturnExpectedValue(double AmountToSpend)
        {
            ByCryptoPage byCryptoPage = mainPage.GoToByCryptoPage();
            byCryptoPage.EnterAmountToSpend(Convert.ToString(AmountToSpend));
            balanceBeforeByCrypto = byCryptoPage.GetSpendBalance();
            byCryptoGetAmount = byCryptoPage.GetSpendAmount();
            byCryptoPage.ByCrypto();
            balanceAfterByCrypto = byCryptoPage.GetSpendBalance();
            Assert.AreEqual(Math.Round(balanceBeforeTransfer + byCryptoGetAmount, 3), Math.Round(balanceAfterTransfer, 3));
        }

        [Test]
        [TestCase("1")]
        public void MakeDeposit_ReturnExpectedValue(string DepositAmount)
        {
            DepositPage depositPage= mainPage.GoToDepositPage();
            depositPage.MakeDeposit(DepositAmount).MakeOutDeposit();
            Assert.AreEqual(depositPage.ReturnDepositAdressValue(), depositPage.ReturnFirstAdressRow());
        }

        [TearDown]
        public void KillWebdriver()
        {
            Driver.Driver.CloseBrowser();
        }
    }
}