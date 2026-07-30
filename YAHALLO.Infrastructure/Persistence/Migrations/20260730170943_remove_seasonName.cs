using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remove_seasonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "Manga");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(946));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 17, 9, 41, 83, DateTimeKind.Utc).AddTicks(2546));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "Manga",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                collation: "Latin1_General_CI_AI");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(955));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(959));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1258));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2146));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 30, 16, 59, 4, 381, DateTimeKind.Utc).AddTicks(2263));
        }
    }
}
