using System;
using Microsoft.EntityFrameworkCore.Migrations;
using YAHALLO.Infrastructure.Data.Triggers;

#nullable disable

namespace YAHALLO.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Triggers.CreateTriggerMangaInSertMangaView(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
