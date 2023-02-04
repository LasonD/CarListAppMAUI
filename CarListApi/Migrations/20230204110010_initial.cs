using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Vin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "Vin" },
                values: new object[,]
                {
                    { 1, "Toyota", "Hilux", "67b51cf2-21c1-4fb4-bbc0-9d395ab44dec" },
                    { 2, "Suzuki", "Jimny", "4583a459-e429-4f0a-b1ed-214fa3b4ecb2" },
                    { 3, "Honda", "Pilot", "9744706d-4936-4445-94f8-471334874d40" },
                    { 4, "Subaru", "Impreza", "1e1dae03-2d37-4f67-93bc-a31b7b39d746" },
                    { 5, "Opel", "Astra", "1cfcb423-d762-48fd-8e71-c25c30ed9d6a" },
                    { 6, "Mercedes Benz", "C Klasse", "a9fb2c41-8b01-4ca1-a9e2-dbaba9e795ff" },
                    { 7, "Tesla", "Model X", "b25bdf17-0eae-4963-aa02-55a76d09911c" },
                    { 8, "Jeep", "Patriot", "9c78f97a-61f3-43f2-bb11-7f162fea5d25" },
                    { 9, "Honda", "Prelude", "23e4293b-556d-4e6c-b7d4-a10e1694770d" },
                    { 10, "Mazda", "MX-5", "f020ba4e-1242-494a-a83c-35c485314a46" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
