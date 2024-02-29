using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class SettingPortoflioInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_AspNetUsers_UserId",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolio",
                table: "Portfolio");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6f25cb-130a-42ba-b8eb-ebad8068139c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a8bab5-ba33-445e-a207-0948a92dd141");

            migrationBuilder.RenameTable(
                name: "Portfolio",
                newName: "Portfolios");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolio_UserId",
                table: "Portfolios",
                newName: "IX_Portfolios_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios",
                columns: new[] { "StockId", "UserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cace965b-e8ff-47cd-842b-3a15bc7c2fc3", "ee010624-3654-4e73-ba4d-9d930e3ff059", "Admin", "ADMIN" },
                    { "e80924f9-0c2d-4c82-8129-b2e65aa2b0fe", "86494eaf-006b-4f6d-b6fe-b4b57a2ff236", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_AspNetUsers_UserId",
                table: "Portfolios",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Stocks_StockId",
                table: "Portfolios",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_AspNetUsers_UserId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Stocks_StockId",
                table: "Portfolios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cace965b-e8ff-47cd-842b-3a15bc7c2fc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80924f9-0c2d-4c82-8129-b2e65aa2b0fe");

            migrationBuilder.RenameTable(
                name: "Portfolios",
                newName: "Portfolio");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolio",
                newName: "IX_Portfolio_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolio",
                table: "Portfolio",
                columns: new[] { "StockId", "UserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6f25cb-130a-42ba-b8eb-ebad8068139c", "e4d91ab1-f20e-49f0-a87f-804fc1c207ab", "User", "USER" },
                    { "74a8bab5-ba33-445e-a207-0948a92dd141", "397ff49c-03a4-4cb0-bd11-0eddba4e2509", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_AspNetUsers_UserId",
                table: "Portfolio",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Stocks_StockId",
                table: "Portfolio",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
