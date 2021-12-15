using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestDerebit
{
    [TestFixture]
    class TestDerebit
    {
        private string username = "kiroki2001@gmail.com";
        private string password = "7mjX5@gPA23YMYc";
        private string webSiteURL = $"https://test.deribit.com/";

        ChromeDriver driver;
        [Test]
        /*public void TransferTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webSiteURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='email']")));

            IWebElement usernameField = driver.FindElement(By.XPath("//*[@id='email']"));
            usernameField.SendKeys(username);
            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id='password']"));
            passwordField.SendKeys(password);
            IWebElement logInButton = driver.FindElement(By.XPath("//button[@data-id='login']"));
            logInButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-id='sideMenuBtn']")));

            IWebElement menuButton = driver.FindElement(By.XPath("//button[@data-id='sideMenuBtn']"));
            menuButton.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-id='transfer']")));
            IWebElement transferMenuButton = driver.FindElement(By.XPath("//a[@data-id='transfer']"));
            transferMenuButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a source')]")));


            IWebElement transferSourceDropDown = driver.FindElement(By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a source')]"));
            transferSourceDropDown.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-']/div[3]/ul/li[2]/div/span")));
            IWebElement transferSourceSelected = driver.FindElements(By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Kiroki')]"))[0];
            transferSourceSelected.Click();
            IWebElement dtransferDestinationDropDown = driver.FindElement(By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Please select a destination')]"));
            dtransferDestinationDropDown.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-']/div[3]/ul/li[3]/div/span")));
            IWebElement transferDestinationSelected = driver.FindElement(By.XPath("//div[@class='MuiListItemText-root'  and contains(span, 'Kiroki_1')]"));
            transferDestinationSelected.Click();

            IWebElement balanceBeforeTransfer = driver.FindElement(By.XPath("//p[@data-id='tradingBalance']"));
            balanceBeforeTransferValue = balanceBeforeTransfer.Text.Split(' ')[0];
            Debug.WriteLine("Before transfer: " + balanceBeforeTransferValue);
            IWebElement amountField= driver.FindElement(By.XPath("//input[@class='MuiInputBase-input']"));
            amountField.SendKeys(amountToSend.ToString());
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-id='transferBtn']")));
            IWebElement transferButton = driver.FindElement(By.XPath("//button[@data-id='transferBtn']"));
            // какой-нибудь afterupdate
            //Thread.Sleep(1000);
            //IWebElement transferCommission = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div[2]/p"));
            //transferCommisionValue = transferCommission.Text.Split(' ')[0];
            //Debug.WriteLine("Commision: " + transferCommisionValue);
            transferButton.Click();
            //wait.Until(ExpectedConditions.) //afterupdate
            Thread.Sleep(3000);

            IWebElement balanceAfterTransfer = driver.FindElement(By.XPath("//p[@data-id='availableBalance']"));
            balanceAfterTransferValue = balanceAfterTransfer.Text.Split(' ')[0];
            Debug.WriteLine("After transfer: " + balanceAfterTransferValue);

            balanceBeforeTransferValue = balanceBeforeTransferValue.Replace('.', ',');
            balanceAfterTransferValue = balanceAfterTransferValue.Replace('.', ',');
            //transferCommisionValue = transferCommisionValue.Replace('.', ',');
            //deltaValue = Convert.ToDouble(balanceBeforeTransferValue) - amountToSend -Convert.ToDouble(transferCommisionValue);
            //Debug.WriteLine("deltaValue: " + deltaValue);

            //Assert.AreEqual(deltaValue, Convert.ToDouble(balanceAfterTransferValue));
            Assert.AreNotEqual(Convert.ToDouble(balanceBeforeTransferValue), Convert.ToDouble(balanceAfterTransferValue));
        }*/

        [TearDown]
        public void KillWebdriver()
        {
            driver.Quit();
        }
    }
}