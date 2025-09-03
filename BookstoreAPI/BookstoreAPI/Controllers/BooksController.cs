// In Controllers/BooksController.cs
using BookstoreAPI.DAL;
using BookstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDataAccess _bookDataAccess;

        public BooksController(BookDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult Get()
        {
            // This endpoint uses the connected model with SqlDataReader
            return Ok(_bookDataAccess.GetAllBooks());
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
           // Input validation could be added here [cite: 24]
            if (book == null)
            {
                return BadRequest("Book object is null");
            }
            _bookDataAccess.AddBook(book);
            return Ok("Book added successfully.");
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (book == null || book.Id != id)
            {
                return BadRequest("Book object is invalid or ID mismatch.");
            }
            _bookDataAccess.UpdateBook(book);
            return Ok("Book updated successfully.");
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookDataAccess.DeleteBook(id);
            return Ok("Book deleted successfully.");
        }

        // GET: api/Books/disconnected
        [HttpGet("disconnected")]
        public IActionResult GetDisconnected()
        {
            // This endpoint demonstrates the disconnected model with DataSet
            DataSet ds = _bookDataAccess.GetAllBooksDisconnected();
            // In a real app, you might manipulate the DataSet here before returning or updating
            // For example, adding a new row programmatically:
            DataTable? booksTable = ds.Tables["Books"];
            if (booksTable != null)
            {
                DataRow newRow = booksTable.NewRow();
                newRow["Title"] = "New Disconnected Book";
                newRow["Author"] = "ADO.NET";
                newRow["Price"] = 99.99m;
                booksTable.Rows.Add(newRow); // This is a CRUD operation on the DataTable [cite: 39]

                // Now, persist this change back to the database
                _bookDataAccess.UpdateBooksFromDataSet(ds);
            }

            return Ok("Demonstrated disconnected model. Check the database for 'New Disconnected Book'.");
        }
    }
}