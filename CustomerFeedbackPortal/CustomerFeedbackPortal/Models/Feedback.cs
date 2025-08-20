// In Models/Feedback.cs
using System.ComponentModel.DataAnnotations;

public class Feedback
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    public string Comments { get; set; }
}