using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Entities.S3
{
    public class Chapter: S3FileBase
    {
        public required string MangaId { get; set;}
        public override string GenerateKey()
        {
            return $"chapters/{MangaId}/{Id}/{FileName}";
        }
    }
}
