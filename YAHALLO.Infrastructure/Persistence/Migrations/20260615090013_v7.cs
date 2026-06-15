using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserEntityId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MangaRating",
                table: "MangaRating");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Comment",
                newName: "CommentToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment",
                newName: "IX_Comment_CommentToUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "MangaRating",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MangaRating",
                table: "MangaRating",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MangaRating_UserId_MangaId",
                table: "MangaRating",
                columns: new[] { "UserId", "MangaId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment",
                column: "CommentToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MangaRating",
                table: "MangaRating");

            migrationBuilder.DropIndex(
                name: "IX_MangaRating_UserId_MangaId",
                table: "MangaRating");

            migrationBuilder.RenameColumn(
                name: "CommentToUserId",
                table: "Comment",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CommentToUserId",
                table: "Comment",
                newName: "IX_Comment_UserEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "MangaRating",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MangaRating",
                table: "MangaRating",
                columns: new[] { "UserId", "MangaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserEntityId",
                table: "Comment",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
