using Microsoft.AspNetCore.Mvc;
using OnlineBankingApp.Services;
using System.Text.Json;

namespace OnlineBankingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username)
        {
            var user = _authService.Authenticate(username);
            if (user != null)
            {
                // Store the entire user object in the session as a JSON string
                var userJson = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("User", userJson);
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Error = "Invalid username. Try 'jane.user' or 'john.admin'.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}