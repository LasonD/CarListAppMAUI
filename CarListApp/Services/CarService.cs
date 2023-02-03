using CarListApp.Models;
using SQLite;

namespace CarListApp.Services
{
    public class CarService
    {
        private readonly string _dbPath;
        private SQLiteConnection _connection;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        public CarService Init()
        {
            if (_connection != null)
            {
                return this;
            }

            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Car>();

            return this;
        }

        public IEnumerable<Car> GetCars()
        {
            return _connection.Table<Car>().ToList();
        }

        public Car GetById(int id)
        {
            return _connection.Table<Car>().SingleOrDefault(c => c.Id == id);
        }

        public int DeleteCar(int id)
        {
            return _connection.Delete<Car>(id);
        }

        public void AddCar(Car car)
        {
            _connection.Insert(car);
        }
    }
}
