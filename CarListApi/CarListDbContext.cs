using Microsoft.EntityFrameworkCore;

public class CarListDbContext : DbContext
{
    public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>().HasData(
            new Car()
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Hilux",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 2,
                Brand = "Suzuki",
                Model = "Jimny",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 3,
                Brand = "Honda",
                Model = "Pilot",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 4,
                Brand = "Subaru",
                Model = "Impreza",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 5,
                Brand = "Opel",
                Model = "Astra",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 6,
                Brand = "Mercedes Benz",
                Model = "C Klasse",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 7,
                Brand = "Tesla",
                Model = "Model X",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 8,
                Brand = "Jeep",
                Model = "Patriot",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 9,
                Brand = "Honda",
                Model = "Prelude",
                Vin = Guid.NewGuid().ToString(),
            },
            new Car()
            {
                Id = 10,
                Brand = "Mazda",
                Model = "MX-5",
                Vin = Guid.NewGuid().ToString(),
            }
        );
    }
}

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Vin { get; set; }
}