using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize(Roles = "User,Admin")] // Both User and Admin can access
    public class UserController : Controller
    {
        public IActionResult TaskList()
{
    var taskWithMaliciousContent = new SecureTaskManager.Models.TaskItem {
        Id = 1,
        Title = "Demo Task",
        Description = "<script>alert('XSS Attack!');</script> This is a task description."
    };
    return View(taskWithMaliciousContent);
}
        
        [Authorize(Policy = "CanEditTaskPolicy")] // Only users with the "CanEditTask" claim can access [cite: 27]
        public IActionResult EditTask(int id)
        {
            // Pretend we are fetching a task to edit
            ViewBag.Message = "You have permission to edit this task because you have the 'CanEditTask' claim.";
            return View();
        }
    }
}