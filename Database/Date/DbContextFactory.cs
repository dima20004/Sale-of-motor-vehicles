using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace Database.Date
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseSqlite($"Filename = {Directory.GetCurrentDirectory}/Autosaloon.db");
            return new DatabaseContext(options.Options);
        }
    }
}
