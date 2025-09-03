// Controllers/DataController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// Applying [Authorize] at the controller level requires a valid token for all actions within.
[Authorize] // [cite: 17, 46]
public class DataController : ControllerBase
{
    // This endpoint can be accessed by any authenticated user (Admin or User).
    [HttpGet("public")]
    public IActionResult GetPublicData()
    {
        var userName = User.Identity?.Name;
        return Ok($"Hello, {userName}! This is public data for all authenticated users.");
    }

    // This endpoint can only be accessed by users with the "Admin" role. [cite: 46]
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")] // [cite: 45]
    public IActionResult GetAdminData()
    {
        return Ok("This is sensitive data, accessible only by users with the 'Admin' role.");
    }

    // This endpoint can only be accessed by users with the "User" role.
    [HttpGet("user")]
    [Authorize(Roles = "User")] // [cite: 45]
    public IActionResult GetUserData()
    {
        return Ok("This is data for users with the 'User' role.");
    }
}