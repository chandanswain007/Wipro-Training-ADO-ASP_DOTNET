using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize] // Protects all actions in this controller [cite: 20]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}