using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPages.Models;

namespace AdvancedRazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = AddModel.Products;
        }
    }
}