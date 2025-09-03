using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize(Roles = "Admin")] // Only users in the "Admin" role can access this [cite: 25]
    public class AdminController : Controller
    {
        public IActionResult ManageTasks()
        {
            return View();
        }
    }
}