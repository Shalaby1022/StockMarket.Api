using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class AddingUSerToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63dcab17-08a9-4da7-aba6-c64da416ee70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b13ee3f3-0853-4ff2-b442-642551cb6f95");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04232067-e9e8-431f-9e57-bebd9f59fe72", "e5ed1445-0074-4880-9798-a08c63cbf147", "User", "USER" },
                    { "695bbb41-0eb8-420c-b722-597d14a7e164", "4c86f8ea-2c70-4250-9348-ca6ff32024c5", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04232067-e9e8-431f-9e57-bebd9f59fe72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "695bbb41-0eb8-420c-b722-597d14a7e164");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63dcab17-08a9-4da7-aba6-c64da416ee70", "0b209f31-5b20-427c-8f4e-c516532dfb1e", "User", "USER" },
                    { "b13ee3f3-0853-4ff2-b442-642551cb6f95", "63d81e45-25b3-4b5e-9ac7-f7725a0c11fa", "Admin", "ADMIN" }
                });
        }
    }
}
