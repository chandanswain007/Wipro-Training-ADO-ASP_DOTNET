using BookstoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApp.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> GetByIsbnAsync(string isbn);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}