using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookstoreApp.Validators
{
    public class ValidIsbnAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var isbn = value as string;
            if (string.IsNullOrEmpty(isbn))
            {
                return new ValidationResult("ISBN is required.");
            }

            // Simple regex for ISBN-10 or ISBN-13
            var regex = new Regex(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$");
            if (regex.IsMatch(isbn))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please enter a valid ISBN-10 or ISBN-13 format.");
        }
    }
}