using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Repositories;
using System.Threading.Tasks;

namespace BookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: /Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllAsync();
            return View(books);
        }

        // GET: /Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: /book/{isbn} - Custom Route Action
        public async Task<IActionResult> DetailsByIsbn(string isbn)
        {
            var book = await _bookRepository.GetByIsbnAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }
            return View("Details", book); // Reuse the Details view
        }
    }
}