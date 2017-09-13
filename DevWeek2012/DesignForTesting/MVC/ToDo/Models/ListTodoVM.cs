using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class ListTodoVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
    }
}