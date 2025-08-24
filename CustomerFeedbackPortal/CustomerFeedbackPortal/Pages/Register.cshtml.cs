// In Pages/Register.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public UserRegistration User { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        // User registration logic goes here
        return RedirectToPage("Success"); // Redirect on successful registration
    }
}