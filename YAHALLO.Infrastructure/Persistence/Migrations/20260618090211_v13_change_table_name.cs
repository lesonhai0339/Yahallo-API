using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v13_change_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_PhoneCode_CountryId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_PhoneCode_CountryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneCode",
                table: "PhoneCode");

            migrationBuilder.RenameTable(
                name: "PhoneCode",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneCode_PhoneCode",
                table: "Country",
                newName: "IX_Country_PhoneCode");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneCode_Code",
                table: "Country",
                newName: "IX_Country_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Country_CountryId",
                table: "Manga",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Country_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Country_CountryId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Country_CountryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "PhoneCode");

            migrationBuilder.RenameIndex(
                name: "IX_Country_PhoneCode",
                table: "PhoneCode",
                newName: "IX_PhoneCode_PhoneCode");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Code",
                table: "PhoneCode",
                newName: "IX_PhoneCode_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneCode",
                table: "PhoneCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_PhoneCode_CountryId",
                table: "Manga",
                column: "CountryId",
                principalTable: "PhoneCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PhoneCode_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "PhoneCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
