using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v3_add_mention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mention",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RootCommentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    MentionFrom = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChapterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserCreate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserDelete = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mention_Users_UserId",
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
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5678));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5688));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 16, 4, 55, 5, 76, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.CreateIndex(
                name: "IX_Manga_CreateDate",
                table: "Manga",
                column: "CreateDate");

            migrationBuilder.CreateIndex(
                name: "IX_Mention_UserId_Seen",
                table: "Mention",
                columns: new[] { "UserId", "Seen" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mention");

            migrationBuilder.DropIndex(
                name: "IX_Manga_CreateDate",
                table: "Manga");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4064));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 10, 8, 20, 10, 501, DateTimeKind.Utc).AddTicks(5183));
        }
    }
}
