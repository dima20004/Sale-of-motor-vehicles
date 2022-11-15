using Database.Models.Base;

namespace Database.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public virtual List<Auto> Autos { get; set; }
    }
}
