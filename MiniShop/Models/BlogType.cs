using System.ComponentModel.DataAnnotations;

namespace MiniShop.Models
{
    public class BlogType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
