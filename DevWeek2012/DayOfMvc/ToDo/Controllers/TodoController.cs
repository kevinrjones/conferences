using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;
using TodoModel;
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
            IList<Todo> todos = _repository.GetTodos();
            List<ListTodoVM> todoVMs = new List<ListTodoVM>();
            foreach (var todo in todos)
            {
                ListTodoVM vm = new ListTodoVM{Entry = todo.Item, Title = todo.Title, Id = todo.Id};
                todoVMs.Add(vm);
            }
            return View(todoVMs);
        }

        [HttpGet]
        public ActionResult New()
        {
            NewTodo model = new NewTodo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewTodo model)
        {
            if(!ModelState.IsValid)
            {
                return View("New", model);
            }
            Todo todo = new Todo {Item = model.Entry, Title = model.Title, Posted = DateTime.Now, State = 1};
            _repository.Create(todo);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Todo entity = _repository.GetTodo(id);
            NewTodo model = new NewTodo {Entry = entity.Item, Title = entity.Title, Id = id};
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(NewTodo model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }
            Todo todo = _repository.GetTodo(model.Id);
            todo.Title = model.Title;
            todo.Item = model.Entry;
            _repository.Update(todo);
            return RedirectToAction("Index");
        }

    }
}
