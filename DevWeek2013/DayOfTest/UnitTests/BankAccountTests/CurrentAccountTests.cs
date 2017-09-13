using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankAccount;
using BankAccountDataAccess;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BankAccountTests
{
    // BDD
    // Given_When_Then

    [TestFixture]
    public class CurrentAccountTests 
    {
        CurrentAccount _currentAccount;
        Mock<IBankDAO> dao;
        private Mock<ILogger> _logger;
        [SetUp]
        public void Setup()
        {
            dao = new Mock<IBankDAO>();
            _logger = new Mock<ILogger>();
            _currentAccount = new CurrentAccount(dao.Object, _logger.Object);
        }

        [Test]
        public void WhenAnAccountIsOpen_ThenItCannotBeReopened()
        {
            _currentAccount.Open(0);

            Assert.That(() => _currentAccount.Open(100), Throws.TypeOf<InvalidStateException>());
        }

        [Test]
        public void GivenABankAccount_WhenItIsInCreditBalance_AndIWithdrawLessThanTheCurrentBalance_ThenTheWithdrawalIsAllowed()
        {
            // Arrange
            _currentAccount.Open(100);

            // Act
            _currentAccount.Withdraw(43);

            _currentAccount.Balance.Should().Be(57);
        }

        [Test, TestCaseSource("myData")]       
        public void GivenANewBankAccount_WhenItIsCreated_ThenTheInitialBalanceIsSet(int initialValue)
        {
            // AAA
            // Arrange

            // Act
            _currentAccount.Open(initialValue);

            // Assert
            Assert.AreEqual(initialValue, _currentAccount.Balance);
        }

        [Test]
        public void GivenAnInvalidAccountId_WhenGettingTheWithdrawalLimit_ThenABankAccountExceptionIsThrown()
        {
            dao.Setup(d => d.GetAccount(It.IsAny<int>())).Throws<Exception>();
            Assert.Throws<BankAccountException>(() => _currentAccount.GetWithdrawalLimt(1));            
        }

        [Test]
        public void WhenAnAccountIsOpened_ThenTheAttemptIsLogged()
        {
            _currentAccount.Open(200);
            _logger.Verify(l => l.LogMessage("Try to open account"), Times.Once());
        }

        [Test]
        public void GivenAWithdrawalLimit_ThenTheCorrectLimitIsReturned()
        {
            var account = new Mock<IAccount>();            
            account.Setup(a => a.GetLimit()).Returns(1000);
            dao.Setup(d => d.GetAccount(It.IsAny<int>())).Returns(account.Object);
            var limit = _currentAccount.GetWithdrawalLimt(1);
            limit.Should().Be(1000);
        }

        [Test]
        public void GivenAValidState_WhenIDoSomething_ThenTheBalanceIsCorrect()
        {
            _currentAccount.Open(100);
            _currentAccount.GetBalance().Should().Be(100);
        }

        [Test]
        public void GWT()
        {
            var myAccount = new MyAccount(null);

            myAccount.UseProtectedMethod();
        }

        int[] myData = new int[]
            {
                100, 200
            };
    }

    class MyAccount : CurrentAccount
    {
        public MyAccount(IBankDAO dao) : base(dao, null)
        {
        }

        public void UseProtectedMethod()
        {
            SetupAccount();
        }
    }
}
