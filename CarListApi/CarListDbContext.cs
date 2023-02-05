using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CarListDbContext : IdentityDbContext
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

        var roles = new IdentityRole[]
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "Administrator".ToUpperInvariant(),
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "User".ToUpperInvariant(),
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        var hasher = new PasswordHasher<IdentityUser>();

        var users = new IdentityUser[]
        {
            new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com".ToUpperInvariant(),
                NormalizedUserName = "admin@localhost.com".ToUpperInvariant(),
                PasswordHash = hasher.HashPassword(null, "P@assword1"),
                EmailConfirmed = true,
            },
            new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "user@localhost.com",
                NormalizedEmail = "user@localhost.com".ToUpperInvariant(),
                NormalizedUserName = "user@localhost.com".ToUpperInvariant(),
                PasswordHash = hasher.HashPassword(null, "P@assword11323"),
                EmailConfirmed = true,
            }
        };

        modelBuilder.Entity<IdentityUser>().HasData(users);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = roles[0].Id,
                UserId = users[0].Id,
            },
            new IdentityUserRole<string>()
            {
                RoleId = roles[1].Id,
                UserId = users[1].Id,
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