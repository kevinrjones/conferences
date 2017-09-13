using System.ComponentModel.DataAnnotations;

namespace Todo.Models.Users
{
    public class LogonViewModel
    {
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string RedirectTo { get; set; }

    }
}