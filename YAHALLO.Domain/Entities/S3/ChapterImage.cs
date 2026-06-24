using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Entities.S3
{
    public class ChapterImage: S3FileBase
    {
        public required string MangaId { get; set;}
        public override string GenerateKey()
        {
            return $"public/manga_chapters/{MangaId}/{Id}/{FileName}";
        }
        public override string Prefix => "public/manga_chapters";

    }
}
