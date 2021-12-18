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

namespace TestDerebit
{
    [TestFixture]
    class TestDerebit
    {
        private string username = "kiroki2001@gmail.com";
        private string password = "7mjX5@gPA23YMYc";
        private string webSiteURL = $"https://test.deribit.com/";
        private LoginPage loginPage;

        public double balanceBeforeTransfer;
        public double balanceAfterTransfer;
        public double balanceBeforeByCrypto;
        public double balanceAfterByCrypto;
        public double byCryptoGetAmount;
        ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webSiteURL);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
        }
        [Test]
        [TestCase(1)]
        public void Transfer_returnExpectedValue(double TransferAmount)
        {
            
            TransferPage transferPage = loginPage.LoginAs(username, password).GoToTransferPage();
            balanceBeforeTransfer = transferPage.GetTransferBalance();
            transferPage.MakeTransfer(Convert.ToString(TransferAmount));
            Thread.Sleep(1000);
            balanceAfterTransfer = transferPage.GetTransferBalance();
            double expected = balanceBeforeTransfer - TransferAmount;
            Console.WriteLine(balanceBeforeTransfer);
            Console.WriteLine(expected);
            double real = balanceAfterTransfer;
            Console.WriteLine(real);
            Assert.AreEqual(expected, real);
        }


        [Test]
        [TestCase(1000)]
        public void ByCrypto_ReturnExpectedValue(double AmountToSpend)
        {
            ByCryptoPage byCryptoPage = loginPage.LoginAs(username, password).GoToByCryptoPage();
            byCryptoPage.EnterAmountToSpend(Convert.ToString(AmountToSpend));
            balanceBeforeByCrypto = byCryptoPage.GetSpendBalance();
            byCryptoGetAmount = byCryptoPage.GetSpendAmount();
            byCryptoPage.ByCrypto();
            balanceAfterByCrypto = byCryptoPage.GetSpendBalance();
            Assert.AreEqual(Math.Round(balanceBeforeTransfer + byCryptoGetAmount, 3), Math.Round(balanceAfterTransfer, 3));
        }

        [TearDown]
        public void KillWebdriver()
        {
            driver.Quit();
        }
    }
}