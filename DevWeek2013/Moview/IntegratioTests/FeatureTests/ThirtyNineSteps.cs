using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace FeatureTests
{
    [Binding]
    public class ThirtyNineSteps
    {
        private IWebDriver _driver;

        [BeforeFeature()]
        public void BeforeFeature()
        {
            _driver = new FirefoxDriver();
        }

        [Given(@"I have movies in the database")]
        public void GivenIHaveMoviesInTheDatabase()
        {
            _driver.Navigate().GoToUrl("http://localhost:49342");
        }

        [When(@"I press list the movies")]
        public void WhenIPressListTheMovies()
        {
        }

        [Then(@"the correct number of movies should be shown")]
        public void ThenTheCorrectNumberOfMoviesShouldBeShown()
        {
            IWebElement dropDown = _driver.FindElement(By.CssSelector("ul li"));
            Assert.That(dropDown.Size, Is.EqualTo(2));
        }
    }
}

