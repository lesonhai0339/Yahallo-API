using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MangaDailyAnalytics_MangaId_CreateDate",
                table: "MangaDailyAnalytics");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MangaDailyAnalytics",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserDailyActivity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SearchCount = table.Column<int>(type: "int", nullable: false),
                    ActiveMinutes = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    LastActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDailyActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDailyActivity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMangaDailyRead",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChapterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMangaDailyRead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMangaDailyRead_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8505));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 9, 39, 29, 652, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.CreateIndex(
                name: "IX_MangaDailyAnalytics_MangaId_Date",
                table: "MangaDailyAnalytics",
                columns: new[] { "MangaId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDailyActivity_UserId_Date",
                table: "UserDailyActivity",
                columns: new[] { "UserId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_ChapterId",
                table: "UserMangaDailyRead",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_MangaId_Date",
                table: "UserMangaDailyRead",
                columns: new[] { "MangaId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMangaDailyRead_UserId_ChapterId_Date",
                table: "UserMangaDailyRead",
                columns: new[] { "UserId", "ChapterId", "Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDailyActivity");

            migrationBuilder.DropTable(
                name: "UserMangaDailyRead");

            migrationBuilder.DropIndex(
                name: "IX_MangaDailyAnalytics_MangaId_Date",
                table: "MangaDailyAnalytics");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MangaDailyAnalytics");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 7, 3, 26, 46, 276, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.CreateIndex(
                name: "IX_MangaDailyAnalytics_MangaId_CreateDate",
                table: "MangaDailyAnalytics",
                columns: new[] { "MangaId", "CreateDate" },
                unique: true);
        }
    }
}
