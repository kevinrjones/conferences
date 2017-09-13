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

namespace ToDoTest.Unit.Controllers
{
    [TestFixture]
    public class TodoControllerTest
    {
        private Mock<ITodoRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ITodoRepository>();
        }

        [Test]
        public void GivenATodoController_WhenIAskForAListOfTodos_ThenIGetTheFullList()
        {
            _repository.Setup(r => r.GetTodos()).Returns(new List<Todo> { new Todo() });
            TodoController controller = new TodoController(_repository.Object);
            var result = controller.Index() as ViewResult;

            var model = result.Model as List<ListTodoVM>;

            Assert.That(model.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenATodoController_WhenIAskToEditATodo_ThenITheEditView()
        {
            int id = 1;
            _repository.Setup(r => r.GetTodo(It.IsAny<int>())).Returns(new Todo { Id = id });
            TodoController controller = new TodoController(_repository.Object);
            var result = controller.Edit(id) as ViewResult;

            var model = result.Model as NewTodo;

            Assert.That(model.Id, Is.EqualTo(id));
        }

    }
}
