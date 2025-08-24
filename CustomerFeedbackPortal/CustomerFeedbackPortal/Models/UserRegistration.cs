// In Models/UserRegistration.cs
using System.ComponentModel.DataAnnotations;

public class UserRegistration
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [MatchPassword("Password")] // Custom Validation Attribute
    public string ConfirmPassword { get; set; }
}