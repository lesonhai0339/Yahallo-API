using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class doi_index_Chapter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapter_Id_Index",
                table: "Chapter");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_MangaId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapter_MangaId_Index",
                table: "Chapter");

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
                name: "IX_Chapter_Id_Index",
                table: "Chapter",
                columns: new[] { "Id", "Index" },
                unique: true,
                filter: "[DeleteDate] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_MangaId",
                table: "Chapter",
                column: "MangaId");
        }
    }
}
