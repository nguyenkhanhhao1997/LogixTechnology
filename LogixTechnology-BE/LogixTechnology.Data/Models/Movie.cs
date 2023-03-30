using System.ComponentModel.DataAnnotations;

namespace LogixTechnology.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
