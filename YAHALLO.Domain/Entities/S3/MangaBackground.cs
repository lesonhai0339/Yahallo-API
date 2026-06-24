using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Entities.S3
{
    public class MangaBackground: S3FileBase
    {
        public override string GenerateKey()
        {
            return $"public/manga_backgrounds/{Id}/{FileName}";
        }
        public override string Prefix => "public/manga_backgrounds";

    }
}
