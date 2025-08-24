using Microsoft.AspNetCore.Mvc;
using OnlineBankingApp.Filters;

namespace OnlineBankingApp.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))] // Protects the entire controller
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transfer()
        {
            // In a real app, this would perform a transaction.
            ViewBag.Message = "This is the secure transfer page.";
            return View();
        }
    }
}