using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;

namespace Database.Date
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseSqlite($"Filename = {Directory.GetParent(Environment.CurrentDirectory).FullName}\\Database\\Autosalon.db");
            //options.UseSqlite($"Filename = Autosalon.db");
            return new DatabaseContext(options.Options);
        }
    }
}
