using ECommercePlatform.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics; // This might be needed depending on your Error view

namespace ECommercePlatform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Apply the AuthenticationFilter using ServiceFilter to enable DI
        [ServiceFilter(typeof(AuthenticationFilter))]
        public IActionResult SecureProductPage()
        {
            return View();
        }

        // This action will test our exception filter
        public IActionResult ThrowError()
        {
            throw new InvalidOperationException("This is a test exception!");
        }

        // This is the single, correct Error action method.
        // It's used by our custom exception filter to show a friendly error page.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Note: The default template puts a view model here. For this assignment,
            // simply returning the view is sufficient because our custom exception
            // filter is handling the logic.
            return View();
        }
    }
}