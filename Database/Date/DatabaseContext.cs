using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Date
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Auto> Auto { get; set; }
    }
}
