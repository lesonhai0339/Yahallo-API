using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v13_add_replyToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplyToCommentId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReplyToCommentId",
                table: "Comment",
                column: "ReplyToCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ReplyToCommentId",
                table: "Comment",
                column: "ReplyToCommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ReplyToCommentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ReplyToCommentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ReplyToCommentId",
                table: "Comment");
        }
    }
}
