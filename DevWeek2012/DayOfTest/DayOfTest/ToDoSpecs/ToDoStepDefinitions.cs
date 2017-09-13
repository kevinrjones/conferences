using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace ToDoSpecs
{
    [Binding]
    public class ToDoStepDefinitions
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new InternetExplorerDriver();
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
        }

        [When(@"I press browse to the home page")]
        public void WhenIPressBrowseToTheHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:6030/");
        }

        [Then(@"the todo list should be displayed")]
        public void ThenTheTodoListShouldBeDisplayed()
        {
            var elem = _driver.FindElement(By.ClassName("todos"));
            Assert.That(elem, Is.Not.Null);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
