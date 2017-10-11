
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
            // Verify we are on the expected webpage.
            Assert.True(driver.Url.Contains("maps"));  
            // Click into Search box.
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).Click();
            // Send keys "Portlan"
            driver.FindElement(By.XPath("//*[@id=\"searchboxinput\"]")).SendKeys("Portland");
            // Click the Search glass
            driver.FindElement(By.Id("searchbox-searchbutton")).Click();
            System.Threading.Thread.Sleep(2000);
            // Click Zoom in button. 
            driver.FindElement(By.XPath("//*[@id=\"pane\"]/div/div[2]/div/div/div[4]/div[1]/button")).Click();
            System.Threading.Thread.Sleep(1000);
            // Click photograph of Portland Customs House
            driver.FindElement(By.XPath("//*[@id=\"pane\"]/div/div[2]/div/div/div[1]/div[1]/button[1]")).Click();
            System.Threading.Thread.Sleep(2000);
            // Click the back arrow
            driver.FindElement(By.XPath("//jsl/div[3]/div[8]/div[24]/div[1]/div[2]/div[8]/div/button[1]")).Click();
            // Click the X on the search box to clear it out. 
            driver.FindElement(By.XPath("//*[@id=\"searchbox\"]/a")).Click();
            //Verify that the title has updated. This indicates that the search box has been cleared.
            Assert.True(driver.Title.Contains("Google Maps"));

        }
    }
}