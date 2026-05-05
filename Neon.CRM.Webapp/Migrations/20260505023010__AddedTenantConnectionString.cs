using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neon.CRM.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class _AddedTenantConnectionString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantConnectionId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent1",
                column: "TenantConnectionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent2",
                column: "TenantConnectionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "agent3",
                column: "TenantConnectionId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantConnectionId",
                table: "AspNetUsers");
        }
    }
}
