using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ToDo.Controllers;
using ToDo.Models;
using TodoModel;
using TodoRepository.Interfaces;

namespace ToDoUnitTests.Controllers
{
    [TestFixture]
    class ToDoControllerTest
    {
        private Mock<ITodoRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ITodoRepository>();
        }

        [Test]
        public void GivenAListOfTodos_WhenTheIndexActionIsCalled_ThenTheFullListIsReturned()
        {
            _repository.Setup(r => r.GetTodos()).Returns(new List<Todo>{new Todo(), new Todo(), new Todo()});

            ToDoController controller = new ToDoController(_repository.Object);
            var result = controller.Index() as ViewResult;
            var data = result.Model as List<ToDoListViewModel>;

            Assert.That(data.Count, Is.EqualTo(3));
        }
    }
}
