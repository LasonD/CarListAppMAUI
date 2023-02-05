using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e309462e-5b1f-4a7b-9fcd-539669205329", "353bc40b-d9bf-46a2-9f22-1a8319d33f30", "Administrator", "ADMINISTRATOR" },
                    { "e9a8b44b-6b74-426e-a26f-87214c179252", "37acabc8-0198-4c15-8dbe-35f9711dc468", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d", 0, "9ff73f79-6711-4af9-ae04-165c8e45dee7", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEBi7c0loQOzWcmWI+hvCM9kDRtgOkOsvnK+T3nSnH+uA2YlHFD9eJzlMqL+OtaiOQQ==", null, false, "6337dc92-15a1-4024-a200-18281bac8e4e", false, null },
                    { "ec1e09b0-82ee-4c88-a736-8a62c13aa63b", 0, "e306f655-7964-4eb6-8ada-5e101ca5b6a5", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEDdXS9U0DK9oGI7nbkMU/gpoq3NF8OySGUt1f64QbTug4MRqxzzQw0CNie6Sjr+FiQ==", null, false, "23573e84-e9b8-459f-9911-8cf7a602cf34", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Vin",
                value: "29d5f82b-d851-4cce-98aa-a02487b5af38");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Vin",
                value: "b4deb577-91ff-468e-a666-1b49766b35ed");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Vin",
                value: "108dd979-1bf2-45e7-85f3-d61d56cc6442");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Vin",
                value: "369a98f3-7b50-46c3-be6f-780739df01a9");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Vin",
                value: "79072114-a629-41be-8a37-e712f75a8f3a");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Vin",
                value: "b5dbb743-493e-4141-bb40-5d03498f8f91");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "Vin",
                value: "a0f40304-dc1e-4098-9734-ddc482896871");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "Vin",
                value: "5a4265c8-d94b-428f-9165-f35bc0c1d68e");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "Vin",
                value: "e430c71e-4ea4-4de3-9e8c-14e3d1a31f52");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "Vin",
                value: "9609b06b-0d1c-4ee9-9f40-0f720cc8b4af");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e9a8b44b-6b74-426e-a26f-87214c179252", "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d" },
                    { "e309462e-5b1f-4a7b-9fcd-539669205329", "ec1e09b0-82ee-4c88-a736-8a62c13aa63b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9a8b44b-6b74-426e-a26f-87214c179252", "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e309462e-5b1f-4a7b-9fcd-539669205329", "ec1e09b0-82ee-4c88-a736-8a62c13aa63b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e309462e-5b1f-4a7b-9fcd-539669205329");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9a8b44b-6b74-426e-a26f-87214c179252");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd7a8e1b-c4f7-4dc9-8431-d8d1a7461c0d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec1e09b0-82ee-4c88-a736-8a62c13aa63b");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Vin",
                value: "761c3e55-cfec-462a-ab7a-676f80eda491");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Vin",
                value: "137e93a0-d350-4e76-b8d0-74fbdb586769");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Vin",
                value: "2f739a9c-7d9b-42bc-a93f-363d785acff4");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Vin",
                value: "321e25d3-f7d2-47bc-a458-8db14057d61b");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Vin",
                value: "f9210806-baf8-4d4a-ab80-5ce1623a5832");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Vin",
                value: "8ae1cfe9-5585-42d1-b971-14a316497ba2");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "Vin",
                value: "779cd62d-6468-4eac-95a8-74f4480de882");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "Vin",
                value: "b6032d22-e6b1-4052-9ab6-1b3ea81755db");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                column: "Vin",
                value: "095550d0-5da8-47da-ba63-0403601dc0e8");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "Vin",
                value: "a6d237b6-8df3-47f3-b84b-372291094375");
        }
    }
}
