using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v12_fix_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentId",
                table: "Comment",
                column: "ParentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment",
                column: "CommentToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserEntityId",
                table: "Comment",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserEntityId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ParentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_CommentToUserId",
                table: "Comment",
                column: "CommentToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
