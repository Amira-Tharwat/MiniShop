using MiniShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Util
{
    public class MaxPriceForCompanyAttribute : ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceForCompanyAttribute(int maxPrice)
        {
            _maxPrice = maxPrice;
        }
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {

            Product p = (Product)validationContext.ObjectInstance;
            int price;
            if (!int.TryParse(value.ToString(), out price))
            {
                return new ValidationResult("enter int value");
            }
            if (p.CompanyId == 1 && price > _maxPrice)
            {
                return new ValidationResult("nike price less than " + _maxPrice.ToString());
            }
            return ValidationResult.Success;
        }
    }
}
