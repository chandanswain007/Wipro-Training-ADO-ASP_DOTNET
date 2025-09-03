using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Data;
using BookstoreApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookstoreApp.Pages.AdminBooks
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly BookstoreApp.Data.ApplicationDbContext _context;

        public IndexModel(BookstoreApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}
