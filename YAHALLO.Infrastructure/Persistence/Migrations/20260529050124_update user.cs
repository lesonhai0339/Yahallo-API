using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3342da35de724c58af31dad9948aecf3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4610a7cea7c94dffab22a15dd74d6317");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9380646f5b8943ddbc2ab773e8825dff");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bbf492bd66df4b498bcfdbc07a69eb49");

            migrationBuilder.AddColumn<string>(
                name: "AvatarThumbnail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "RoleCode", "RoleDescription", "RoleName", "UpdateDate" },
                values: new object[,]
                {
                    { "49813fb8f73946cc90ecfee661cfa934", null, null, null, null, null, 2, "Normal User or New User has this Role", "User", null },
                    { "4ccf75accf2d401399a93d07b68e0dab", null, null, null, null, null, 4, "If User has this role then User can use Create, Update, Delete Manga", "Upload", null },
                    { "9da0a58d614548bd8eaa257ee61b537d", null, null, null, null, null, 3, "Role for Moderator", "Mod", null },
                    { "bbad5ec3dd004884a5f36587234ea32f", null, null, null, null, null, 1, "Only Admin has this Role", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "49813fb8f73946cc90ecfee661cfa934");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ccf75accf2d401399a93d07b68e0dab");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9da0a58d614548bd8eaa257ee61b537d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bbad5ec3dd004884a5f36587234ea32f");

            migrationBuilder.DropColumn(
                name: "AvatarThumbnail",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "RoleCode", "RoleDescription", "RoleName", "UpdateDate" },
                values: new object[,]
                {
                    { "3342da35de724c58af31dad9948aecf3", null, null, null, null, null, 3, "Role for Moderator", "Mod", null },
                    { "4610a7cea7c94dffab22a15dd74d6317", null, null, null, null, null, 4, "If User has this role then User can use Create, Update, Delete Manga", "Upload", null },
                    { "9380646f5b8943ddbc2ab773e8825dff", null, null, null, null, null, 1, "Only Admin has this Role", "Admin", null },
                    { "bbf492bd66df4b498bcfdbc07a69eb49", null, null, null, null, null, 2, "Normal User or New User has this Role", "User", null }
                });
        }
    }
}
