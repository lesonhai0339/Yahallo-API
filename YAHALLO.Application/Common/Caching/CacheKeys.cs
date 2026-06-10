using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Keys
{
    public static class CacheKeys
    {
        public const string MangaDetailPrefix = "manga:detail:";
        public static string MangaDetail(string id) => $"{MangaDetailPrefix}{id}";
        public static string Home => "Homepage";

    }
}
