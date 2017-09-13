using System;
using DfTModel;
using Moq;
using NUnit.Framework;

namespace UserDaoTests
{
    [TestFixture]
    public class ApplicationTest
    {
        [Test]
        public void WillReturnTheCorrectNumberOfUsers()
        {
            var m = new Mock<IUserDao>();

            m.Setup(u => u.GetCountOfUsers()).Returns(11);

            var app = new Application(m.Object);
            Assert.AreEqual(10, app.Run());
        }
    }

}
