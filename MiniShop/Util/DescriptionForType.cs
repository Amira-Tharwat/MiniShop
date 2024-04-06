using MiniShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Util
{
    public class DescriptionForType : ValidationAttribute
    {
        private readonly int _descriptionLength;
        public DescriptionForType(int DescriptionLength)
        {
            _descriptionLength = DescriptionLength;
        }
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {

            Blog b = (Blog)validationContext.ObjectInstance;

            int x = b.Description.Length;
            if (b.BlogTypeId == 1 && x > _descriptionLength)
            {
                return new ValidationResult("The comedy blog Description must be less than " + _descriptionLength + "chars");
            }
            return ValidationResult.Success;
        }
    }
}
