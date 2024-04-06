using System.ComponentModel.DataAnnotations;

namespace MiniShop.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
