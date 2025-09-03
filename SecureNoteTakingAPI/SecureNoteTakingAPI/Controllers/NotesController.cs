using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureNoteTakingAPI.Data;
using SecureNoteTakingAPI.DTO;
using SecureNoteTakingAPI.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SecureNoteTakingAPI.Controllers
{
    [ApiController]
    [Route("api/notes")]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteDto noteDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note added successfully.", noteId = note.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var notes = await _context.Notes.Where(n => n.UserId == userId).ToListAsync();
            return Ok(notes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, NoteDto noteDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null) return NotFound();

            note.Title = noteDto.Title;
            note.Content = noteDto.Content;
            note.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Note updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null) return NotFound();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Note deleted successfully." });
        }
    }
}
