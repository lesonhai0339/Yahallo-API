using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeletedPagination
{
    public sealed class AdminGetAllAuthorDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllAuthorDeletedPaginationQuery, PagedResult<AdminAuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public AdminGetAllAuthorDeletedPaginationQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<PagedResult<AdminAuthorDto>> Handle(AdminGetAllAuthorDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository
              .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize, 
                selector: x => x
                  .Where(a => !string.IsNullOrEmpty(a.IdUserDelete) && a.DeleteDate.HasValue)
                  .Select(t => new AdminAuthorDto
                  {
                      Id = t.Id,
                      Birth = t.Birth,
                      Country = t.Countries.GetDescription(),
                      Depscription = t.Depscription,
                      LifeStatus = t.LifeStatus.GetDescription(),
                      Name = t.Name
                  }),
                cancellation: cancellationToken,
                ignoreQueryFilters: true);
            return authors.MapToPagedResult(x =>x );
        }
    }
}
