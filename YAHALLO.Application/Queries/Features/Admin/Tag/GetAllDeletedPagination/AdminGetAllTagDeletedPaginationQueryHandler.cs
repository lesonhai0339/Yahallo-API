using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Tag.GetAllDeletedPagination
{
    public sealed class AdminGetAllTagDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllTagDeletedPaginationQuery, PagedResult<AdminTagDto>>
    {
        private readonly ITagRepository _tagRepository;
        public AdminGetAllTagDeletedPaginationQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<PagedResult<AdminTagDto>> Handle(AdminGetAllTagDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                 selector: x => x
                    .Where(t => !string.IsNullOrEmpty(t.IdUserDelete) && t.DeleteDate.HasValue)
                    .Select(x => new AdminTagDto
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Name = x.Name
                    }),
                    cancellationToken,
                    ignoreQueryFilters: true);
            return tags.MapToPagedResult(x => x);
        }
    }
}
