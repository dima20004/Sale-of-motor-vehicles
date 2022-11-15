using Microsoft.EntityFrameworkCore;

namespace Database.Date
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
