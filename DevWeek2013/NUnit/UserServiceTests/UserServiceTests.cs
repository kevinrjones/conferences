using FluentAssertions;
using Moq;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    [TestFixture]
    public class UserServiceTests
    {
        UserService _userService;
        private Mock<IDataAccess> _dataAccess;
        [SetUp]
        public void Setup()
        {
            _dataAccess = new Mock<IDataAccess>();
            _dataAccess.Setup(m => m.Users()).Returns(new List<User> { new User() });
            _dataAccess.Setup(m => m.Get(It.IsAny<int>())).Returns(new User());
            _userService = new UserService(_dataAccess.Object);
        }

        [Test, TestCaseSource("_userIds")]
        public void GivenAValidUserId_WhenTHatUserIIsOne_ThenICanRetreiveAUserFromTheDatabase(int expected)
        {
            // Act
            var user = _userService.Get(expected);

            // Assert
            user.Id.Should().Be(expected);
        }

        [Test]
        public void GivenAValidUserId_WhenTHatUserIIsTwo_ThenICanRetreiveAUserFromTheDatabase()
        {
            int expected = 2;

            // Act
            var user = _userService.Get(expected);

            // Assert
            Assert.AreEqual(expected, user.Id);
        }

        [Test]
        public void ICanRetrieveAllUsers()
        {
            var users = _userService.GetUsers();

            Assert.That(users.Count(), Is.EqualTo(1));
        }

        private int[] _userIds = new[] {1, 2};
    }
}
