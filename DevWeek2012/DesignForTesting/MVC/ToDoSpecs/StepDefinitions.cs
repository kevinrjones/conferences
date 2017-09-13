using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace ToDoSpecs
{
    [Binding]
    public class StepDefinitions
    {
        IWebDriver _webDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webDriver = new FirefoxDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.Quit();
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
        }

        [When(@"When I navigate to the home page")]
        public void WhenWhenINavigateToTheHomePage()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:1402/");
        }

        [Then(@"I see the list of todos on the page")]
        public void ThenISeeTheListOfTodosOnThePage()
        {
            var elem =_webDriver.FindElement(By.ClassName("todos"));
            Assert.That(elem, Is.Not.Null);
        }


    }
}
