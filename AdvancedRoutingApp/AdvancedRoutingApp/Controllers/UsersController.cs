using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Orders(string username)
        {
            ViewData["Message"] = $"Orders for user: {username}";
            return View();
        }
    }
}