using System;

namespace Todo.Models
{
    public class TodoViewModel
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public int NestingLevel { get; set; }
        public string Number { get; set; }
        public DateTime? TodoDate { get; set; }
        public string TodoText { get; set; }
    }
}

//items.push({id: this.id, todoText: this.todoText, todoDate: this.todoDate, number: this.number, nesting: this.nesting, order: this.order});