using Microsoft.AspNetCore.Mvc;
using MVCPattern.Models;

namespace MVCPattern.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(User user)
        {
            return View("Display", user);
        }
    }
}