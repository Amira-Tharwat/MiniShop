
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShopRazorPages.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the name of product")]
        [Length(1, 10, ErrorMessage = "The name must be less than 10 chars and greater than 1 char")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1000, 10000)]
       // [MaxPriceForCompany(5000)]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool EnableSize { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }


    }
}
