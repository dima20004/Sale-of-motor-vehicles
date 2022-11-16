using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;

namespace Database.Date
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        //Метод создания контекста базы данных
        public DatabaseContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();

            // строка подключения к базе данных
            options.UseSqlite($"Filename = {Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent}\\Database\\Autosalon.db");
            
            return new DatabaseContext(options.Options);
        }
    }
}
