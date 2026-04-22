using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neon.CRM.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingVacationPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VacationPackages",
                columns: new[] { "Id", "Description", "DurationInDays", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Enjoy a week in a tropical paradise with white sandy beaches and crystal-clear waters.", 7, 1999.99m, "Beach Paradise" },
                    { 2, "Experience the thrill of mountain climbing and hiking in breathtaking landscapes.", 5, 1499.99m, "Mountain Adventure" },
                    { 3, "Discover the vibrant culture and history of a bustling city with guided tours and activities.", 3, 999.99m, "City Explorer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
