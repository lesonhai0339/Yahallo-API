using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixMangaAuthorFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaAuthor_Manga_AuthorId",
                table: "MangaAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaAuthor_Manga_MangaId",
                table: "MangaAuthor",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaAuthor_Manga_MangaId",
                table: "MangaAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaAuthor_Manga_AuthorId",
                table: "MangaAuthor",
                column: "AuthorId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
