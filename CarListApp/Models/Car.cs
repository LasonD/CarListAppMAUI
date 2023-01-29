namespace CarListApp.Models
{
    internal class Car : EntityBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
    }
}
