using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Dashboard()
    {
        var users = _userManager.Users.ToList();
        var userDetails = new List<UserDetailViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userDetails.Add(new UserDetailViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles.ToList()
            });
        }

        ViewBag.Message = $"Welcome, {User.Identity.Name}! You have access to the Admin Dashboard.";
        return View(userDetails);
    }
}

public class UserDetailViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}