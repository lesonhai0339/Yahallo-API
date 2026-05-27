using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "RoleCode", "RoleDescription", "RoleName", "UpdateDate" },
                values: new object[,]
                {
                    { "57845090ee7c43ce829eaa2a6a728ca2", null, null, null, null, null, 4, "If User has this role then User can use Create, Update, Delete Manga", "Upload", null },
                    { "b83869e557514c6bb6faebb35316095e", null, null, null, null, null, 2, "Normal User or New User has this Role", "User", null },
                    { "d8876ea6abf742c09fb0dda27122f8a9", null, null, null, null, null, 3, "Role for Moderator", "Mod", null },
                    { "de0ada2dd2fc4345aecc2626776dc3b6", null, null, null, null, null, 1, "Only Admin has this Role", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57845090ee7c43ce829eaa2a6a728ca2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b83869e557514c6bb6faebb35316095e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d8876ea6abf742c09fb0dda27122f8a9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "de0ada2dd2fc4345aecc2626776dc3b6");
        }
    }
}
