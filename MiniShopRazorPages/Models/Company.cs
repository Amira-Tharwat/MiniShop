using System.ComponentModel.DataAnnotations;

namespace MiniShopRazorPages.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
