using Microsoft.AspNetCore.Mvc;

namespace ECommercePlatform.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                // Set a session variable to simulate login
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Username is required";
            return View();
        }

        public IActionResult Logout()
        {
            // Clear the session to simulate logout
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}