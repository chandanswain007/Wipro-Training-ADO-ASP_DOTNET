using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookstoreApp.ViewModels;
using BookstoreApp.Repositories;
using BookstoreApp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        public List<CartItemViewModel> Cart { get; set; } = new();
        public decimal CartTotal { get; set; }

        public CartModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            CartTotal = Cart.Sum(item => item.Total);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int id)
        {
            Cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var cartItem = Cart.FirstOrDefault(i => i.BookId == id);
            if (cartItem == null)
            {
                Cart.Add(new CartItemViewModel
                {
                    BookId = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetObject("Cart", Cart);
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveFromCart(int id)
        {
            Cart = HttpContext.Session.GetObject<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();
            var itemToRemove = Cart.SingleOrDefault(r => r.BookId == id);
            if (itemToRemove != null)
            {
                Cart.Remove(itemToRemove);
                HttpContext.Session.SetObject("Cart", Cart);
            }
            return RedirectToPage();
        }
    }
}