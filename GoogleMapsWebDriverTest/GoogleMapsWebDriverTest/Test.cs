
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Alerts_and_Windows
{ 
    [TestFixture]
    class GoogleMapsWebDrivertest

    {
       
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com/maps");
        }

        [TearDown]
        public void teardown()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void GoogleMapsTest()
        {
            Assert.True(driver.Url.Contains("maps"));           //Verify we are on the expected webpage.
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).SendKeys("Portland");
            driver.FindElement(By.Id("searchbox-searchbutton")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath("//jsl/div[3]/div[8]/div[24]/div[1]/div[2]/div[8]/div/button[1]")).Click();
            Assert.True(driver.Title.Contains("Google Maps"));  //Verify that the title has updated. This indicates that the search box has been cleared.
            driver.FindElement(By.Id("sb_cb50")).Click();

        }
    }
}