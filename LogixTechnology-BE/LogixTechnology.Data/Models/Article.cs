using System.ComponentModel.DataAnnotations;

namespace LogixTechnology.Data.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
