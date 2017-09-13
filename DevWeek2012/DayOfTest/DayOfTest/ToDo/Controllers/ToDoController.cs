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
    public class ToDoController : Controller
    {
        private readonly ITodoRepository _repository;

        public ToDoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            List<ToDoListViewModel> model = new List<ToDoListViewModel>();
            var entities = _repository.GetTodos();

            foreach (var entity in entities)
            {
                ToDoListViewModel m = new ToDoListViewModel {Title = entity.Title, Entry = entity.Item};
                model.Add(m);
            }

            return View(model);
        }

    }
}
