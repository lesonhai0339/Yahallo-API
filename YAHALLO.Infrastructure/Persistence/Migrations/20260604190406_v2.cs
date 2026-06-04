using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MangaEntityId",
                table: "Image",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_MangaEntityId",
                table: "Image",
                column: "MangaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Manga_MangaEntityId",
                table: "Image",
                column: "MangaEntityId",
                principalTable: "Manga",
                principalColumn: "Id");
        }
    }
}
