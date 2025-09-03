using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _genreRepository.GetAllAsync());
        }

        // POST: Genres/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.AddAsync(genre);
                await _genreRepository.SaveAsync(); // <-- CORRECTED LINE
                return Json(new { success = true, genre });
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return Json(new { success = false, message = "Genre not found." });
            }
            _genreRepository.Delete(genre);
            await _genreRepository.SaveAsync();
            return Json(new { success = true });
        }
    }
}
