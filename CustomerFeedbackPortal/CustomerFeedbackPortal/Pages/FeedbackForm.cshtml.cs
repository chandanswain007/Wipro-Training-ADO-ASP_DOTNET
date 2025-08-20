// In Pages/FeedbackForm.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FeedbackFormModel : PageModel
{
    [BindProperty]
    public Feedback Feedback { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        // Process the valid data (e.g., save to a database)
        // For now, we'll just redirect to a success page.
        return RedirectToPage("Success");
    }
}