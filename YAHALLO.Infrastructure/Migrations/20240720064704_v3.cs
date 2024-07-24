using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserReplyId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserReplyId",
                table: "Comment"); 

            migrationBuilder.DropColumn(
                name: "UserReplyId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Comment",
                newName: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MangaSeason",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Season",
                table: "MangaSeason",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "CanComment",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanHide",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanLike",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanRemove",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanReply",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisLikeCount",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentAttechment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAttechment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentAttechment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentAttechment_ParentId",
                table: "CommentAttechment",
                column: "ParentId",
                unique: true);

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
                name: "FK_Comment_Users_UserEntityId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "CommentAttechment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserEntityId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MangaSeason");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "MangaSeason");

            migrationBuilder.DropColumn(
                name: "CanComment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CanHide",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CanLike",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CanRemove",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CanReply",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "DisLikeCount",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Comment",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "UserReplyId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");
            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserReplyId",
                table: "Comment",
                column: "UserReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserReplyId",
                table: "Comment",
                column: "UserReplyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
