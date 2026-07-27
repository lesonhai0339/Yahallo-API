using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class doi_index_Chapter_and_add_SubIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapter_MangaId_Index",
                table: "Chapter");

            migrationBuilder.AddColumn<int>(
                name: "SubIndex",
                table: "Chapter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(934));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1255));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1675));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 40, 14, 100, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_MangaId_Index_SubIndex",
                table: "Chapter",
                columns: new[] { "MangaId", "Index", "SubIndex" },
                unique: true,
                filter: "[DeleteDate] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapter_MangaId_Index_SubIndex",
                table: "Chapter");

            migrationBuilder.DropColumn(
                name: "SubIndex",
                table: "Chapter");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249",
                column: "CreateDate",
                value: new DateTime(2026, 7, 27, 15, 33, 23, 590, DateTimeKind.Utc).AddTicks(6798));

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_MangaId_Index",
                table: "Chapter",
                columns: new[] { "MangaId", "Index" },
                unique: true,
                filter: "[DeleteDate] IS NULL");
        }
    }
}
