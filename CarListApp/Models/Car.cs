using SQLite;

namespace CarListApp.Models
{
    [Table(nameof(Car))]
    public class Car : EntityBase
    {
        [NotNull]
        public string Brand { get; set; }

        [NotNull]
        public string Model { get; set; }

        [MaxLength(17), Unique]
        public string Vin { get; set; }
    }
}
