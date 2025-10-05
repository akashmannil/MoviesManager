
using System.ComponentModel.DataAnnotations;

namespace MoviesManager.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        public int Year { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Rating should be between 0 and 10")]
        public double Rating { get; set; }
        
        public string Cast { get; set; }
        
        
    }
}