using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockMarket.DataService.Migrations
{
    /// <inheritdoc />
    public partial class AddingOneToOneFromCommentToAppUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cace965b-e8ff-47cd-842b-3a15bc7c2fc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80924f9-0c2d-4c82-8129-b2e65aa2b0fe");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f6d0c6b-681a-4c20-a4dd-b50b29b09531", "1e27f3cb-9b37-45f2-97a8-6fec819bcd60", "Admin", "ADMIN" },
                    { "a4a03a79-c99f-4a9c-975d-088ca81b384b", "a89d009a-e119-401f-a388-4fd9213a7f7f", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f6d0c6b-681a-4c20-a4dd-b50b29b09531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4a03a79-c99f-4a9c-975d-088ca81b384b");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cace965b-e8ff-47cd-842b-3a15bc7c2fc3", "ee010624-3654-4e73-ba4d-9d930e3ff059", "Admin", "ADMIN" },
                    { "e80924f9-0c2d-4c82-8129-b2e65aa2b0fe", "86494eaf-006b-4f6d-b6fe-b4b57a2ff236", "User", "USER" }
                });
        }
    }
}
