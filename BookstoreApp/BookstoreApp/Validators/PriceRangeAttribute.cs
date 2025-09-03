using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Validators
{
    public class PriceRangeAttribute : ValidationAttribute
    {
        private readonly double _minPrice;
        private readonly double _maxPrice;

        public PriceRangeAttribute(double minPrice, double maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var price = (decimal)value;
            if (price >= (decimal)_minPrice && price <= (decimal)_maxPrice)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Price must be between ${_minPrice:C} and ${_maxPrice:C}.");
        }
    }
}