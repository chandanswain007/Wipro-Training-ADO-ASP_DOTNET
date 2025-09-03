using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        
        // Task<Genre> GetGenreByNameAsync(string name);
    }
}