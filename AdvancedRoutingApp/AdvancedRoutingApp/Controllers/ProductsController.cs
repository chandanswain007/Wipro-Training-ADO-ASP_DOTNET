using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Details(string category, int id)
        {
            ViewData["Message"] = $"Product in category: {category}, ID: {id}";
            return View();
        }
    }
}