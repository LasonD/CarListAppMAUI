// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarListApi.Migrations
{
    [DbContext(typeof(CarListDbContext))]
    [Migration("20230204110010_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            Model = "Hilux",
                            Vin = "67b51cf2-21c1-4fb4-bbc0-9d395ab44dec"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Suzuki",
                            Model = "Jimny",
                            Vin = "4583a459-e429-4f0a-b1ed-214fa3b4ecb2"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Honda",
                            Model = "Pilot",
                            Vin = "9744706d-4936-4445-94f8-471334874d40"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Subaru",
                            Model = "Impreza",
                            Vin = "1e1dae03-2d37-4f67-93bc-a31b7b39d746"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Opel",
                            Model = "Astra",
                            Vin = "1cfcb423-d762-48fd-8e71-c25c30ed9d6a"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Mercedes Benz",
                            Model = "C Klasse",
                            Vin = "a9fb2c41-8b01-4ca1-a9e2-dbaba9e795ff"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Tesla",
                            Model = "Model X",
                            Vin = "b25bdf17-0eae-4963-aa02-55a76d09911c"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Jeep",
                            Model = "Patriot",
                            Vin = "9c78f97a-61f3-43f2-bb11-7f162fea5d25"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Honda",
                            Model = "Prelude",
                            Vin = "23e4293b-556d-4e6c-b7d4-a10e1694770d"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Mazda",
                            Model = "MX-5",
                            Vin = "f020ba4e-1242-494a-a83c-35c485314a46"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
