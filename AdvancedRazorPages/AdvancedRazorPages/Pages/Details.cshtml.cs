using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPages.Models;

namespace AdvancedRazorPages.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = AddModel.Products.FirstOrDefault(p => p.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}