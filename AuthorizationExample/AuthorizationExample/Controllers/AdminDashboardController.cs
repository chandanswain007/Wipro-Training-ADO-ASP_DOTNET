using Microsoft.AspNetCore.Mvc;

namespace AuthorizationExample.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
