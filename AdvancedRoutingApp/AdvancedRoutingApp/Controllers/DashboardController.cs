using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Simulate user role (in real app, use User.Identity or session)
            string userRole = HttpContext.Session.GetString("UserRole") ?? "regular";

            if (userRole == "admin")
            {
                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("UserDashboard");
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}