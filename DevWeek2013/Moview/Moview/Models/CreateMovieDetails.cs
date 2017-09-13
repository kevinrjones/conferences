using System.ComponentModel.DataAnnotations;

namespace Moview.Models
{
    public class CreateMovieDetails
    {
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        public string Director { get; set; }
    }
}