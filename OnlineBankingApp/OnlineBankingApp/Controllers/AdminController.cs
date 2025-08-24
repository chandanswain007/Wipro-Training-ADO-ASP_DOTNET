using Microsoft.AspNetCore.Mvc;
using OnlineBankingApp.Filters;

namespace OnlineBankingApp.Controllers
{
    // Apply filters in order: first check for login, then check for admin role.
    [ServiceFilter(typeof(AuthenticationFilter))]
    [ServiceFilter(typeof(AdminAuthorizationFilter))]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllAccounts()
        {
            ViewBag.Message = "Here you can see all user accounts.";
            return View();
        }
    }
}