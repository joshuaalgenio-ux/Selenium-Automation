using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            driver.Navigate().GoToUrl("https://youtube.com");
            Assert.IsTrue(driver.Url.Contains("youtube"));
            Assert.That(driver.Title, Is.EqualTo("Youtube"));
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