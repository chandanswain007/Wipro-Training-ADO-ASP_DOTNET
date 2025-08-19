using Microsoft.EntityFrameworkCore;
using MyRazorApp.model; // <-- Use lowercase "m" to match your folder

namespace MyRazorApp.Data
{
    public class EcomContext : DbContext
    {
        public EcomContext(DbContextOptions<EcomContext> options)
            : base(options)
        {
        }

        public DbSet<category> Categories { get; set; }
        //public DbSet<product> Products { get; set; }
    }
}