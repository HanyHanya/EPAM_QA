using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System; 

namespace DerebitTest
{
    [TestFixture]
    class Tests
    {
        private string username = "kiroki2001@gmail.com";
        private string password = "7mjX5@gPA23YMYc";
        private string webSiteURL = $"https://test.deribit.com/";
        [Test]
        public void TransferTest()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(webSiteURL);

        }
    }
}
