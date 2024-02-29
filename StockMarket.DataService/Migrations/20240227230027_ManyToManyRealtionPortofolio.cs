using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRealtionPortofolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04232067-e9e8-431f-9e57-bebd9f59fe72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "695bbb41-0eb8-420c-b722-597d14a7e164");

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => new { x.StockId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Portfolio_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolio_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6f25cb-130a-42ba-b8eb-ebad8068139c", "e4d91ab1-f20e-49f0-a87f-804fc1c207ab", "User", "USER" },
                    { "74a8bab5-ba33-445e-a207-0948a92dd141", "397ff49c-03a4-4cb0-bd11-0eddba4e2509", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UserId",
                table: "Portfolio",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6f25cb-130a-42ba-b8eb-ebad8068139c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a8bab5-ba33-445e-a207-0948a92dd141");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04232067-e9e8-431f-9e57-bebd9f59fe72", "e5ed1445-0074-4880-9798-a08c63cbf147", "User", "USER" },
                    { "695bbb41-0eb8-420c-b722-597d14a7e164", "4c86f8ea-2c70-4250-9348-ca6ff32024c5", "Admin", "ADMIN" }
                });
        }
    }
}
