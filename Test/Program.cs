// See https://aka.ms/new-console-template for more information
//Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
/*var fikalis = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent}\\Database\\Autosalon.db";
Console.WriteLine(fikalis);*/
using Database.Date;
using Database.Models;

using (var dbContext = new DbContextFactory().CreateDbContext())
{
    // создание новой записи для пользователя
    /*dbContext.User.Add(new Database.Models.User
    {
        Name = "Анто",
        SecondName = "Фикалис",
        Login = "fikalis",
        Password = "123"
    });*/

    // удаление пользователя с именем Анто
    List<User> user = dbContext.User.ToList();

    dbContext.Set<User>().Remove(dbContext.User.FirstOrDefault(user => user.Name == "Анто"));

    // сохранение изменений в БД
    dbContext.SaveChanges();    
}
