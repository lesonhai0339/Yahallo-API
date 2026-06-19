using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v15_reaction_targets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisLike",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "IsLike",
                table: "Reaction");

            migrationBuilder.AddColumn<string>(
                name: "ChapterId",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MangaId",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reaction",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ChapterId",
                table: "Reaction",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_MangaId",
                table: "Reaction",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Chapter_ChapterId",
                table: "Reaction",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Comment_CommentId",
                table: "Reaction",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Manga_MangaId",
                table: "Reaction",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Chapter_ChapterId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Comment_CommentId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Manga_MangaId",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_ChapterId",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_CommentId",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_MangaId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "Reaction");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisLike",
                table: "Reaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLike",
                table: "Reaction",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
