using Database.Models.Base;

namespace Database.Models
{
    public class Auto : BaseEntity
    {
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public double Price { get; set; }
        public uint Year { get; set; }
        public uint Mileage { get; set; }
        public string Color { get; set; }
        public string Body { get; set; }
        public string Engine { get; set; }
        public double Tax { get; set; }
        public string KPP { get; set; }
        public string Drive { get; set; }
        public string Status { get; set; }
        public string PTS { get; set; }
        public string? Description { get; set; }
        public virtual User? Owner { get; set; }

    }
}
