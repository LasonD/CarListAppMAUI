using CarListApp.Models;
using System.Collections.Immutable;

namespace CarListApp.Services
{
    internal class CarService
    {
        public IImmutableList<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car
                {
                    Id = 1,
                    Brand = "BMW",
                    Model = "M3",
                    Vin = Guid.NewGuid().ToString(),
                },
                new Car
                {
                    Id = 2,
                    Brand = "Audi",
                    Model = "A4 B8",
                    Vin = Guid.NewGuid().ToString(),
                },
                new Car
                {
                    Id = 3,
                    Brand = "Alfa Romeo",
                    Model = "Brera",
                    Vin = Guid.NewGuid().ToString(),
                },
            }.ToImmutableList();
        }
    }
}
