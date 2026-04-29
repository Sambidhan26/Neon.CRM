using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neon.CRM.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class _AddedCustomerSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "AgentId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Beach Paradise Lane", "agent1", "sammyboy.quarter@example.com", "Sammyboy", "Quarter", "123-456-7890" },
                    { 2, "456 Mountain Adventure Lane", "agent2", "mountain.adventure@example.com", " Adventure", "Experience", "987-654-3210" },
                    { 3, "789 City Explorer Lane", "agent3", "city.explorer@example.com", "Explorer", "Discover", "555-555-5555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
