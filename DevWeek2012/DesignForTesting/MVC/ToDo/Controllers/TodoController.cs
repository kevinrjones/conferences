using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;
using TodoRepository.Interfaces;
using TodoRepository.Repositories;

namespace ToDo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            List<ListTodoVM> viewModels = new List<ListTodoVM>();
            var todos = _repository.GetTodos();
            foreach (var todo in todos)
            {
                ListTodoVM model = new ListTodoVM {Title = todo.Title, Entry = todo.Item};
                viewModels.Add(model);
            }
            return View(viewModels);
        }

    }
}
