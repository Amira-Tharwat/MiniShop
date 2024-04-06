using System.ComponentModel.DataAnnotations;

namespace MiniShop.Models.DTO
{
    public class ProductDTO
    {

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
        //[Required]
        //public int Quantity { get; set; }
        [Required]
        public bool EnableSize { get; set; }
        [Required]
        public int CompanyId { get; set; }

        public Company? company { get; set; }

    }
}
