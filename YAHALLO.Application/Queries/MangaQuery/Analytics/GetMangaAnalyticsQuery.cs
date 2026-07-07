using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.MangaDaily;

namespace YAHALLO.Application.Queries.MangaQuery.Analytics
{
    public class GetMangaAnalyticsQuery: IRequest<GetMangaAnalyticsResult>
    {
        public string MangaId { get; init; } = null!;
        public DateTime From {  get; init; }
        public  DateTime To { get; init; }  
        public MangaDailyFilterBy FilterBy { get; init; } = MangaDailyFilterBy.Day;
    }
    public record GetMangaAnalyticsResult
    {
        public int TotalChapter { get; set; }
        public List<MangaAnalytics> MangaAnalytics { get; set; } = new List<MangaAnalytics>();
    }
    public record MangaAnalytics
    {
        public string MangaId { get; init; } = null!;
        public int TotalFollower { get; init; }
        public int TotalView { get; init; }
        public int TotalComment { get; init; }
        public int Day { get; init; }
        public int Month { get; init; }
        public int Year { get; init; }
    }
}
