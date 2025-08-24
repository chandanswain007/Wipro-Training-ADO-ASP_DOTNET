// In Validation/MatchPasswordAttribute.cs
using System.ComponentModel.DataAnnotations;

public class MatchPasswordAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public MatchPasswordAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
        if (property == null)
        {
            throw new ArgumentException("Property with this name not found");
        }

        var comparisonValue = property.GetValue(validationContext.ObjectInstance);
        if (!object.Equals(value, comparisonValue))
        {
            return new ValidationResult("The Password and Confirmation Password do not match.");
        }
        return ValidationResult.Success;
    }
}