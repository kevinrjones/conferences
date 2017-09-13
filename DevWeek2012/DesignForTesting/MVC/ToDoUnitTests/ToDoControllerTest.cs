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

namespace ToDoUnitTests
{
    [TestFixture]
    public class ToDoControllerTest
    {
        [Test]
        public void GivenALoggedInUser_WhenThenExecutueTheTodoIndexMethod_ThenAViewResultIsReturned()
        {
            Mock<ITodoRepository> repository = new Mock<ITodoRepository>();
            repository.Setup(r => r.GetTodos()).Returns(new List<Todo>());


            TodoController controller = new TodoController(repository.Object);
            var result = controller.Index();
            Assert.That(result, Is.TypeOf(typeof(ViewResult)));
        }

        [Test]
        public void GivenThreeTodosInTheDatabase_WhenIndexIsCalled_ThenThreeViewModelsArePassedToTheView()
        {
            Mock<ITodoRepository> repository = new Mock<ITodoRepository>();
            repository.Setup(r => r.GetTodos()).Returns(new List<Todo>{new Todo(), new Todo(), new Todo()});
            TodoController controller = new TodoController(repository.Object);
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<ListTodoVM>;

            Assert.That(model.Count, Is.EqualTo(3));
        }
    }
}
