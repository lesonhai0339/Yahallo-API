using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "RoleCode", "RoleDescription", "RoleName", "UpdateDate" },
                values: new object[,]
                {
                    { "478b5e9aba1c42cb814b26ed47412760", null, null, null, null, null, 3, "Role for Moderator", "Mod", null },
                    { "4e5add13a3874804b73484b3311cc422", null, null, null, null, null, 4, "If User has this role then User can use Create, Update, Delete Manga", "Upload", null },
                    { "96c85d7acc6a416c9e33cdd8e7629c87", null, null, null, null, null, 2, "Normal User or New User has this Role", "User", null },
                    { "f25aa70593ee4d9f9fba524a52b7173c", null, null, null, null, null, 1, "Only Admin has this Role", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "478b5e9aba1c42cb814b26ed47412760");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4e5add13a3874804b73484b3311cc422");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "96c85d7acc6a416c9e33cdd8e7629c87");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f25aa70593ee4d9f9fba524a52b7173c");
        }
    }
}
