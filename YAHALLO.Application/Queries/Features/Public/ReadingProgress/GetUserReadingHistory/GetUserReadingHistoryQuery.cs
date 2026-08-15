using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetReadHistoryByUser
{
    public class GetUserReadingHistoryQuery: PaginationQuery<GetUserReadingHistoryResult>
    {
    }
    public record GetUserReadingHistoryResult
    {
        public string MangaId { get; set; } = null!;
        public string MangaName { get; set; } = null!;
        public string? MangaThumbnail { get; set; }
        public ChapterReadingProgress[] Chapters { get; set; } = new ChapterReadingProgress[0];
    }
    public class ChapterReadingProgress
    {
        public string ChapterId { get; set; } = null!;
        public int Index { get; set; }
        public int SubIndex { get; set; }
        public int LastReadPage { get; set; }
        public int TotalPage { get; set; } = 0; 
        public DateTime LastReadAt { get; set; }
    }
}
