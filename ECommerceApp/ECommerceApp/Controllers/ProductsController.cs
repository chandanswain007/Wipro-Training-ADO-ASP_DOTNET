// Controllers/ProductsController.cs
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // Handles /Products/{category}/{id}
        public IActionResult Details(string category, int id)
        {
            var product = _productService.GetProduct(category, id);
            if (product == null)
            {
                return NotFound(); // Product not found
            }
            return View(product); // Pass product to the view
        }
        public IActionResult Filter(string category)
        {
            var products = _productService.GetProductsByCategory(category);
            return View(products); // Create a simple view to list these products
        }
    }
}