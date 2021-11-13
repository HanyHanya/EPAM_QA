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
        private double amountToSend = 1;
        private double deltaValue;
        private string username = "kiroki2001@gmail.com";
        private string password = "7mjX5@gPA23YMYc";
        private string webSiteURL = $"https://test.deribit.com/";
        private string balanceBeforeTransferValue;
        private string balanceAfterTransferValue;
        private string transferCommisionValue;
        

        

        [Test]
        public void TransferTest()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webSiteURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='email']")));

            IWebElement usernameField = driver.FindElement(By.XPath("//*[@id='email']"));
            usernameField.SendKeys(username);
            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id='password']"));
            passwordField.SendKeys(password);
            IWebElement logInButton = driver.FindElement(By.XPath("//*[@id='mainContainer']/div/div[1]/div/form/div[4]/button"));
            logInButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='mainHeader']/header/div/div[1]/button")));

            IWebElement menuButton = driver.FindElement(By.XPath("//*[@id='mainHeader']/header/div/div[1]/button"));
            menuButton.Click();
            IWebElement transferMenuButton = driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div/ul/div[2]/div/div/div[3]/a"));
            transferMenuButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[1]/div[1]/div/div/div/div/span")));


            IWebElement transferSourceDropDown = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[1]/div[1]/div/div/div/div/span"));
            transferSourceDropDown.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-']/div[3]/ul/li[2]/div/span")));
            IWebElement transferSourceSelected = driver.FindElement(By.XPath("//*[@id='menu-']/div[3]/ul/li[2]/div/span"));
            transferSourceSelected.Click();
            IWebElement dtransferDestinationDropDown = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[1]/div[3]/div/div/div/div/span"));
            dtransferDestinationDropDown.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-']/div[3]/ul/li[3]/div/span")));
            IWebElement transferDestinationSelected = driver.FindElement(By.XPath("//*[@id='menu-']/div[3]/ul/li[3]/div/span"));
            transferDestinationSelected.Click();

            IWebElement balanceBeforeTransfer = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[3]/div[2]/p"));
            balanceBeforeTransferValue = balanceBeforeTransfer.Text.Split(' ')[0];
            Debug.WriteLine("Before transfer: " + balanceBeforeTransferValue);
            IWebElement amountField= driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[3]/div/div/div/div[2]/input"));
            amountField.SendKeys(amountToSend.ToString());
            IWebElement transferButton = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[4]/div/div/button"));
            // �����-������ afterupdate
            Thread.Sleep(1000);
            IWebElement transferCommission = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div[2]/p"));
            transferCommisionValue = transferCommission.Text.Split(' ')[0];
            Debug.WriteLine("Commision: " + transferCommisionValue);
            transferButton.Click();
            //wait.Until(ExpectedConditions.) //afterupdate
            Thread.Sleep(3000);

            IWebElement balanceAfterTransfer = driver.FindElement(By.XPath("//*[@id='mainBody']/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[1]/div[2]/p"));
            balanceAfterTransferValue = balanceAfterTransfer.Text.Split(' ')[0];
            Debug.WriteLine("After transfer: " + balanceAfterTransferValue);

            balanceBeforeTransferValue = balanceBeforeTransferValue.Replace('.', ',');
            balanceAfterTransferValue = balanceAfterTransferValue.Replace('.', ',');
            transferCommisionValue = transferCommisionValue.Replace('.', ',');
            deltaValue = Convert.ToDouble(balanceBeforeTransferValue) - amountToSend -Convert.ToDouble(transferCommisionValue);
            Debug.WriteLine("deltaValue: " + deltaValue);

            //������� ��������
            Assert.AreNotEqual(Convert.ToDouble(balanceBeforeTransferValue), Convert.ToDouble(balanceAfterTransferValue));
        }
    }
}