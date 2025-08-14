using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumAutomation
{
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void ExampleTest()
        {
            driver.Navigate().GoToUrl("https://facebook.com");
            Assert.That(driver.Title, Is.EqualTo("Facebook"));
            Console.WriteLine("Test Passed - Title matched");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}