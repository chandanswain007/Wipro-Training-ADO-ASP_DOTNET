using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookstoreApp.Extensions;
using BookstoreApp.ViewModels;

namespace BookstoreApp.Controllers
{
    [Authorize] // Only logged-in users can access order processing
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            if (cart.Count == 0)
            {
                TempData["ErrorMessage"] = "Your cart is empty.";
                return RedirectToAction("Index", "Books");
            }
            return View(cart);
        }

        [HttpPost]
        public IActionResult ProcessOrder()
        {
            var cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart");
            // In a real app, you would save the order to the database,
            // process payment, etc.
            // For this example, we'll just clear the cart.
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}