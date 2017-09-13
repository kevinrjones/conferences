using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        public void WhenItIsPassedAnEmptyString_ThenTheAddMethodReturnsZero()
        {
            int result = _calculator.Add("");
        
            Assert.That(result, Is.EqualTo(0));
        }


        [Test]
        public void WhenItIsPassedANonZeroSingleValue_ThenTheThatValueIsReturned()
        {
            int result = _calculator.Add("1");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void WhenItIsPassedANullValue_ThenAnArgumentExceptionIsThrown()
        {
            Assert.That(_calculator.Add(null), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GivenACallToDumbMethod_ThenItReturnsOne()
        {
            MyCalc calc = new MyCalc();

            Assert.That(calc.DumbHelper(), Is.EqualTo(1));
        }


        [Test]
        public void GivenACallToAnotherDumbMethod_ThenItReturnsOne()
        {
            Assert.That(_calculator.AnotherDumbMethod(), Is.EqualTo(1));
        }
    }

    class MyCalc : StringCalculator
    {
        public int DumbHelper()
        {
            return base.DumbMethod();
        }
    }
}
