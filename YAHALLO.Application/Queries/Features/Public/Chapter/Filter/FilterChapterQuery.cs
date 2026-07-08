using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Chappter;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.Filter
{
    public class FilterChapterQuery: IRequest<PagedResult<ChapterDto>>
    {
        public int PageNo { get;set; }
        public int PageSize { get;set; }
        public int? Index { get; set; }
        public string? MangaId { get; set; }
        public string? MangaName { get; set; }
        public ChapterSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
    }
}
