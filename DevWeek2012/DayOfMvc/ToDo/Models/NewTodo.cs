using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.Models
{
    public class NewTodo //: IValidatableObject
    {
        public int Id { get; set; }
//        [Required]
        [Remote("IsTitleValid", "Validation", HttpMethod="POST")]
        public string Title { get; set; }
        [Required]
        public string Entry { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == "Hello")
        //        yield return new ValidationResult("Invalid title", new[] { "Title" });
        //}
    }
}