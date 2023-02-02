using CarListApp.Models;
using SQLite;
using System.Collections.Immutable;

namespace CarListApp.Services
{
    public class CarService
    {
        private string _dbPath;
        private SQLiteConnection _connection;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_connection != null)
            {
                return;
            }

            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Car>();
        }

        public Task<IEnumerable<Car>> GetCarsAsync()
        {
            Init();
            return Task.FromResult(_connection.Table<Car>().ToList().AsEnumerable());

            // return new List<Car>()
            // {
            //     new Car
            //     {
            //         Id = 1,
            //         Brand = "BMW",
            //         Model = "M3",
            //         Vin = Guid.NewGuid().ToString(),
            //     },
            //     new Car
            //     {
            //         Id = 2,
            //         Brand = "Audi",
            //         Model = "A4 B8",
            //         Vin = Guid.NewGuid().ToString(),
            //     },
            //     new Car
            //     {
            //         Id = 3,
            //         Brand = "Alfa Romeo",
            //         Model = "Brera",
            //         Vin = Guid.NewGuid().ToString(),
            //     },
            // }.ToImmutableList();
        }
    }
}
