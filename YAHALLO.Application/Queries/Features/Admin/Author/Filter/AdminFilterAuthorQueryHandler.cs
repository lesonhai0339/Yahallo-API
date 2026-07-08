using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Author.Filter
{
    public sealed class AdminFilterAuthorQueryHandler : IRequestHandler<AdminFilterAuthorQuery, PagedResult<AdminAuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public AdminFilterAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<PagedResult<AdminAuthorDto>> Handle(AdminFilterAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(t => new AdminAuthorDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Birth = t.Birth,
                        Country = t.Countries.GetDescription(),
                        Depscription = t.Depscription,
                        LifeStatus = t.LifeStatus.GetDescription(),
                        CreateDate = t.CreateDate,
                        DeleteDate = t.DeleteDate,  
                    }),
                cancellation: cancellationToken,
                ignoreQueryFilters: request.IsDeleted);

            return authors.MapToPagedResult(x => x);
        }
        private IQueryable<AuthorEntity> ApplyFilter(IQueryable<AuthorEntity> filter, AdminFilterAuthorQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) filter = filter.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) filter = filter.Where(x => x.Name.Contains(name));

            if (request.Country != null) filter = filter.Where(x => x.Countries == request.Country);

            if (request.LifeStatus != null) filter = filter.Where(x => x.LifeStatus == request.LifeStatus);

            if (request.IsDeleted) //deleted items
                filter = filter.Where(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue);

            return filter;
        }
        private IQueryable<AuthorEntity> ApplySorting(IQueryable<AuthorEntity> filter, AdminFilterAuthorQuery request)
        {
            return filter.OrderBy(x => x.Id);
        }
    }
}
