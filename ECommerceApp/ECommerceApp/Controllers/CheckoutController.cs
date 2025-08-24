// Controllers/CheckoutController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    public class CheckoutController : Controller
    {
        [Authorize] // This attribute protects the action
        public IActionResult Index()
        {
            // This view will only be shown to authenticated users.
            return View();
        }
    }
}