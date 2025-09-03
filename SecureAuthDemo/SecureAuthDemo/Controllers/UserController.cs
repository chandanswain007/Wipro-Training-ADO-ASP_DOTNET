using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "User,Admin")]
public class UserController : Controller
{
    public IActionResult Profile()
    {
        ViewBag.Message = $"Welcome, {User.Identity.Name}! Here is your profile information.";
        return View();
    }
}