using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevWeekDataAccess;
using DevWeekService;
using Moq;
using NUnit.Framework;

namespace DevWeekServicesTest
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserDAO> dao;
        [SetUp]
        public void Setmeup()
        {
            dao = new Mock<IUserDAO>();
            dao.Setup(m => m.GetUsers()).Returns(new List<User>());
        }

        [Test]
        public void GivenTheDatabaseContainsNoUsers_WhenIAskForAllUsers_ThenNoUsersAreReturned()
        {
            // Arrange
            UserService service = new UserService(dao.Object);

            // Act
            var count = service.GetCountOfUsers();

            // Assert
            Assert.That(count, Is.EqualTo(0));
        }
    }

}
