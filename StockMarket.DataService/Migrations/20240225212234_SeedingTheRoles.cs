using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTheRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d43e7a4-c5ac-4891-bad5-2b80aac10e28", "5c3759d8-eec4-4f04-9dc5-d563d6995b32", "Admin", "ADMIN" },
                    { "9a50a651-8343-4613-a97e-9b02377f406d", "488fab2a-d35e-4c6f-a73f-b39a5ff81e39", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d43e7a4-c5ac-4891-bad5-2b80aac10e28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a50a651-8343-4613-a97e-9b02377f406d");
        }
    }
}
