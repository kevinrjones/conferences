using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NetCalculator;
using TechTalk.SpecFlow;

namespace UserUnitFeatures
{
    [Binding]
    class MySteps
    {
        private Calculator _calculator;
        private int _result;
        [BeforeScenario()]
        public void BeforeScenario()
        {
            _result = 0;
            _calculator = new Calculator();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int value)
        {
            _calculator.EnterNumber(value);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
