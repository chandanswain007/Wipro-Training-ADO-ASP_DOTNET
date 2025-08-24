using Microsoft.AspNetCore.Mvc;

public class ItemsController : Controller
{
    public IActionResult Details(Guid itemId)
    {
        ViewData["Message"] = $"Item ID: {itemId}";
        return View();
    }
}