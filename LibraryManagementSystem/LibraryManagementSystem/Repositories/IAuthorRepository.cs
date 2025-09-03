using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {

        //Task<IEnumerable<Author>> GetAuthorsWithBooksAsync();
    }
}