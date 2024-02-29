using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class MovingAppUserIntoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d43e7a4-c5ac-4891-bad5-2b80aac10e28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a50a651-8343-4613-a97e-9b02377f406d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63dcab17-08a9-4da7-aba6-c64da416ee70", "0b209f31-5b20-427c-8f4e-c516532dfb1e", "User", "USER" },
                    { "b13ee3f3-0853-4ff2-b442-642551cb6f95", "63d81e45-25b3-4b5e-9ac7-f7725a0c11fa", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63dcab17-08a9-4da7-aba6-c64da416ee70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b13ee3f3-0853-4ff2-b442-642551cb6f95");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d43e7a4-c5ac-4891-bad5-2b80aac10e28", "5c3759d8-eec4-4f04-9dc5-d563d6995b32", "Admin", "ADMIN" },
                    { "9a50a651-8343-4613-a97e-9b02377f406d", "488fab2a-d35e-4c6f-a73f-b39a5ff81e39", "User", "USER" }
                });
        }
    }
}
