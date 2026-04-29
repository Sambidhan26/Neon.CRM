using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neon.CRM.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class _AddedAgentSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "agent1", 0, "CONCUR1", "agent1@example.com", false, "AgentOne", "Hello1", false, null, "AGENT1@EXAMPLE.COM", "AGENT1", null, null, false, "STAMP1", false, "agent1" },
                    { "agent2", 0, "CONCUR2", "agent2@example.com", false, "AgentTwo", "Hello2", false, null, "AGENT2@EXAMPLE.COM", "AGENT2", null, null, false, "STAMP2", false, "agent2" },
                    { "agent3", 0, "CONCUR3", "agent3@example.com", false, "AgentThree", "Hello3", false, null, "AGENT3@EXAMPLE.COM", "AGENT3", null, null, false, "STAMP3", false, "agent3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent3");
        }
    }
}
