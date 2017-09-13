using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceInterfaces;
using Todo.Models;
using System.Linq;

namespace Todo.Hubs
{
    public class TodoHub : AuthenticatingHub
    {
        private readonly ITodoService _todoService;

        public TodoHub(ITodoService todoService)
        {
            _todoService = todoService;
        }

        private static List<TodoViewModel> GetTodoModels(IEnumerable<Entities.Todo> todos)
        {
            var model = (from t in todos
                         orderby t.Order, t.NestingLevel, t.TodoDate
                         select new TodoViewModel { Id = t.Id, TodoDate = t.TodoDate, TodoText = t.TodoText, NestingLevel = t.NestingLevel, Number = t.Number, Order = t.Order }).ToList();
            return model;
        }

        public Task<List<TodoViewModel>> GetTodos()
        {
            return Task.Factory.StartNew(() =>
                    {
                        if (IsAuthenticated())
                        {
                            var todos = _todoService.GetTodos();
                            var model = GetTodoModels(todos);
                            return model;
                        }
                        return null;
                    });
        }

        public Task<List<TodoViewModel>> AddTodo(TodoViewModel todo)
        {
            return Task.Factory.StartNew(() =>
            {
                if (IsAuthenticated())
                {
                    _todoService.AddTodo(new Entities.Todo { TodoDate = todo.TodoDate, TodoText = todo.TodoText, Order = todo.Order, NestingLevel = todo.NestingLevel, Number = todo.Number});
                    var todos = _todoService.GetTodos();
                    var model = GetTodoModels(todos);
                    return model;
                }
                return null;
            });
        }

        public Task SaveTodo(TodoViewModel todo)
        {
            return Task.Factory.StartNew(() =>
            {
                if (IsAuthenticated())
                {
                    _todoService.SaveTodo(new Entities.Todo { Id = todo.Id, TodoDate = todo.TodoDate, TodoText = todo.TodoText, NestingLevel = todo.NestingLevel, Number = todo.Number, Order = todo.Order });
                }
            });
        }

        public Task SaveTodos(IEnumerable<TodoViewModel> todos)
        {
            return Task.Factory.StartNew(() =>
            {
                if (IsAuthenticated())
                {
                    todos.ToList().ForEach(
                        todo =>
                        _todoService.SaveTodo(new Entities.Todo
                                                  {
                                                      Id = todo.Id,
                                                      TodoDate = todo.TodoDate,
                                                      TodoText = todo.TodoText,
                                                      NestingLevel = todo.NestingLevel,
                                                      Number = todo.Number,
                                                      Order = todo.Order
                                                  }));
                }
            });
        }
    }
}