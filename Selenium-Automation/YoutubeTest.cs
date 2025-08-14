using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomation
{
    public class YoutubeTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCase(TestName = "POR12345-1"),Order(1)]
        public void ExampleTest()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("https://youtube.com");

            //Assert
            Assert.IsTrue(driver.Url.Contains("youtube"));
            Assert.That(driver.Title, Is.EqualTo("YouTube"));
            Console.WriteLine("Test Passed - Title matched");
        }

        [TestCase(TestName = "POR12345-2"), Order(2)]
        public void SearchingTest()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://youtube.com");
            //Act
            var searchTextboxXpath = By.XPath("//input[@name='search_query']");
            var searchBtnXpath = By.XPath("//button[@title='Search']");
            var searchResultsXpath = By.XPath("//span[text()='Bitoy']");

            var searchTextbox = driver.FindElement(searchTextboxXpath);
            searchTextbox.Click();

            searchTextbox.SendKeys("Bitoy");

            driver.FindElement(searchBtnXpath).Click();


            //Assert
            Thread.Sleep(3000);
            var searchResult = driver.FindElement(searchResultsXpath);
            searchResult.Should().NotBeNull();
            searchResult.Text.Should().Contain("Bitoy");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}