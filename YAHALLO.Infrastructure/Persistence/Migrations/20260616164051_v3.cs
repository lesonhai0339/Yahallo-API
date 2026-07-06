using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Users_UserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_MangaSeason_MangaSeasonId",
                table: "Manga");

            migrationBuilder.DropTable(
                name: "MangaSeason");

            migrationBuilder.DropIndex(
                name: "IX_Manga_MangaSeasonId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "RefeshToken",
                table: "UserToken",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "ExpiredRefeshToken",
                table: "UserToken",
                newName: "ExpiredRefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundThumbnail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manga",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                collation: "Latin1_General_CI_AI",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldCollation: "Latin1_General_CI_AI");

            migrationBuilder.AlterColumn<string>(
                name: "MangaSeasonId",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MangaGroupId",
                table: "Manga",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "Manga",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                collation: "Latin1_General_CI_AI");

            migrationBuilder.AlterColumn<string>(
                name: "BaseUrl",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MangaGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true, collation: "Latin1_General_CI_AI"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaGroupId",
                table: "Manga",
                column: "MangaGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_MangaGroup_MangaGroupId",
                table: "Manga",
                column: "MangaGroupId",
                principalTable: "MangaGroup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_MangaGroup_MangaGroupId",
                table: "Manga");

            migrationBuilder.DropTable(
                name: "MangaGroup");

            migrationBuilder.DropIndex(
                name: "IX_Manga_MangaGroupId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "BackgroundThumbnail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MangaGroupId",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "Manga");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "UserToken",
                newName: "RefeshToken");

            migrationBuilder.RenameColumn(
                name: "ExpiredRefreshToken",
                table: "UserToken",
                newName: "ExpiredRefeshToken");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manga",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                collation: "Latin1_General_CI_AI",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldCollation: "Latin1_General_CI_AI");

            migrationBuilder.AlterColumn<string>(
                name: "MangaSeasonId",
                table: "Manga",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BaseUrl",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Image",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MangaSeason",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaSeason", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manga_MangaSeasonId",
                table: "Manga",
                column: "MangaSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserId",
                table: "Image",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Users_UserId",
                table: "Image",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_MangaSeason_MangaSeasonId",
                table: "Manga",
                column: "MangaSeasonId",
                principalTable: "MangaSeason",
                principalColumn: "Id");
        }
    }
}
