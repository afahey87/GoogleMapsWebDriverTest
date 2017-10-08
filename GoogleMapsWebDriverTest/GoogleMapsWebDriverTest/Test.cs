
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
            //driver.Close();
            //driver.Quit();
        }

        [Test]
        public void GoogleMapsTest()
        {
            Assert.True(driver.Url.Contains("maps"));
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).SendKeys("Portland");
            driver.FindElement(By.Id("searchbox-searchbutton")).Click();
            Assert.True(driver.Url.Contains("Portland"));
            //driver.FindElement(By.Id("widget-zoom-in")).Click();
        }
    }
}