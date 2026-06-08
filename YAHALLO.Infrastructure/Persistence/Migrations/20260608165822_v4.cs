using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastChapterId",
                table: "Manga",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manga_LastChapterId",
                table: "Manga",
                column: "LastChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Chapter_LastChapterId",
                table: "Manga",
                column: "LastChapterId",
                principalTable: "Chapter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Chapter_LastChapterId",
                table: "Manga");

            migrationBuilder.DropIndex(
                name: "IX_Manga_LastChapterId",
                table: "Manga");

            migrationBuilder.AlterColumn<string>(
                name: "LastChapterId",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
