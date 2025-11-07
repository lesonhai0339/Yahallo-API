using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Infrastructure.Presistence.Triggers
{
    public class Triggers
    {
        public static OperationBuilder<SqlOperation> CreateTriggerMangaInSertMangaView(MigrationBuilder migrationBuilder)
        {
            return migrationBuilder.Sql(
                @"CREATE TRIGGER tg_manga_insert_mangaview
                ON Manga 
                AFTER INSERT
                AS 
                BEGIN
                    INSERT MangaView(MangaId, [View],CreateDate,IdUserCreate,UpdateDate,IdUserUpdate,DeleteDate,IdUserDelete)
                    SELECT DISTINCT C.Id, 0, null,null,null,null,null,null
                    FROM INSERTED AS C
                END;");
        }
    }
}
