using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Text;

namespace PenAndPaper.NUnit.Selenium
{
    [TestFixture]
    class SeleniumTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private readonly string driverPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\HelpClasses\Selenium\Drivers\"));
        private readonly string baseURL = @"https://www.google.de/";
        private bool acceptNextAlert = true;

        [SetUp]
        public void TestInit()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("intl.accept_languages", "en");
            driver = new FirefoxDriver(driverPath, options);
            //var options = new InternetExplorerOptions();
            //options.IgnoreZoomLevel = true;
            //driver = new InternetExplorerDriver(driverPath, options);
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TestTeardown()
        {
            driver.Quit();
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        [Category("Selenium")]
        public void SeleniumTest()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText(IWebDriver driver)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
