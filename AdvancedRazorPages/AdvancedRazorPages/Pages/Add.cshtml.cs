using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPages.Models;

namespace AdvancedRazorPages.Pages.Products
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        // This would typically be populated from a database
        public static List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // For demonstration, we'll manually assign a new ProductID
            Product.ProductID = Products.Count + 1;
            Products.Add(Product);

            return RedirectToPage("./Index");
        }
    }
}