using Microsoft.EntityFrameworkCore;
using TestRazorWeb.Model;

namespace TestRazorWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        internal readonly IEnumerable<Category> Category;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestRazorWeb.Model.Category> Categories { get; set; }
        
    }
}
