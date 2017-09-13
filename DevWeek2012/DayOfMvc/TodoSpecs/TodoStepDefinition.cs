using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace TodoSpecs
{
    [Binding]
    public class TodoStepDefinition
    {
        private IWebDriver _webdriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webdriver = new FirefoxDriver();
            _webdriver.Navigate().GoToUrl("http://localhost:1261/todo/new");
        }

        [Given(@"I have entered a title")]
        public void GivenIHaveEnteredATitle()
        {
            var elem =_webdriver.FindElement(By.Id("Title"));
            elem.SendKeys("Some Title");
        }

        [Given(@"I have entered the todo entry")]
        public void GivenIHaveEnteredTheTodoEntry()
        {
            var elem = _webdriver.FindElement(By.Id("Entry"));
            elem.SendKeys("Some Entry");
        }

        [When(@"I press create")]
        public void WhenIPressCreate()
        {
            var elem = _webdriver.FindElement(By.ClassName("form"));
            elem.Submit();
        }

        [Then(@"the todo is shown on the results page")]
        public void ThenTheTodoIsShownOnTheResultsPage()
        {
            var elem = _webdriver.FindElement(By.ClassName("todos"));
            Assert.That(elem, Is.Not.Null);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webdriver.Quit();
//            _webdriver.Dispose();
        }
    }
}
