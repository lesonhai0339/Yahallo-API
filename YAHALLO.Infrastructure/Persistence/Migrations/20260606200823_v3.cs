using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MangaEntityId",
                table: "MangaTag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_MangaEntityId",
                table: "MangaTag",
                column: "MangaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaTag_Manga_MangaEntityId",
                table: "MangaTag",
                column: "MangaEntityId",
                principalTable: "Manga",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaTag_Manga_MangaEntityId",
                table: "MangaTag");

            migrationBuilder.DropIndex(
                name: "IX_MangaTag_MangaEntityId",
                table: "MangaTag");

            migrationBuilder.DropColumn(
                name: "MangaEntityId",
                table: "MangaTag");
        }
    }
}
