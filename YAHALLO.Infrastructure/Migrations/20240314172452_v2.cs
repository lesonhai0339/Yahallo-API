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
                    { "0994dbb9490744fe9ba51d623e07d109", null, null, null, null, null, 3, "Role for Moderator", "Mod", null },
                    { "6a8225cb691c49c799f68796a5148cd1", null, null, null, null, null, 2, "Normal User or New User has this Role", "User", null },
                    { "8a2825a011a74b969b75e11b9e910a29", null, null, null, null, null, 4, "If User has this role then User can use Create, Update, Delete Manga", "Upload", null },
                    { "c7044759bc4d43ba97dfef293e4ba5b0", null, null, null, null, null, 1, "Only Admin has this Role", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0994dbb9490744fe9ba51d623e07d109");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6a8225cb691c49c799f68796a5148cd1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8a2825a011a74b969b75e11b9e910a29");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c7044759bc4d43ba97dfef293e4ba5b0");
        }
    }
}
