using SecureNoteTakingAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecureNoteTakingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
