using MediatR;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.Filter
{
    public sealed class AdminFilterMangaQuery: PaginationQuery<AdminMangaDto>
    {
        public string? Name { get; set; }
        public string? TagIds { get; set; }
        public string? AuthorId { get; set; }
        public string? ArtistId { get; set; }
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int Season { get; set; }
        public string? UserId { get; set; }
        public DateTime? Date { get; set; }
        public double TimeZoneOffset { get; set;  }
        public MangaSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
