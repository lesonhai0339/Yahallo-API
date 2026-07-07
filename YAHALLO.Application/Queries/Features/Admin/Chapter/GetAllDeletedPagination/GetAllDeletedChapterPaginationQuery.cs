using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeletedPagination
{
    public sealed class GetAllDeletedChapterPaginationQuery: IRequest<PagedResult<AdminChapterDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get; set; }
      
    }
}
