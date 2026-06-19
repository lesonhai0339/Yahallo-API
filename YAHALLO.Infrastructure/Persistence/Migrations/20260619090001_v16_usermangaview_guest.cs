using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v16_usermangaview_guest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMangaView",
                table: "UserMangaView");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserMangaView",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserMangaView",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VisitorId",
                table: "UserMangaView",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMangaView",
                table: "UserMangaView",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaView_UserId_MangaId_ViewedAt",
                table: "UserMangaView",
                columns: new[] { "UserId", "MangaId", "ViewedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaView_VisitorId_MangaId_ViewedAt",
                table: "UserMangaView",
                columns: new[] { "VisitorId", "MangaId", "ViewedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMangaView",
                table: "UserMangaView");

            migrationBuilder.DropIndex(
                name: "IX_UserMangaView_UserId_MangaId_ViewedAt",
                table: "UserMangaView");

            migrationBuilder.DropIndex(
                name: "IX_UserMangaView_VisitorId_MangaId_ViewedAt",
                table: "UserMangaView");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserMangaView");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "UserMangaView");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserMangaView",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMangaView",
                table: "UserMangaView",
                columns: new[] { "UserId", "MangaId" });
        }
    }
}
