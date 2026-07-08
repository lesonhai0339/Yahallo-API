using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Author.Filter
{
    public class FilterAuthorQueryHandler : IRequestHandler<FilterAuthorQuery, PagedResult<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public FilterAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<PagedResult<AuthorDto>> Handle(FilterAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize, 
                selector: q=>
                    ApplyFilter(q, request)
                    .Select(x => new AuthorDto
                    {
                        Id  = x.Id, 
                        Name = x.Name,
                        Depscription = x.Depscription,
                        Birth = x.Birth,
                        Countries = x.Countries,    
                        LifeStatus = x.LifeStatus   
                    }),
                cancellationToken
                );
            return authors.MapToPagedResult(x =>  x);
        }
        private IQueryable<AuthorEntity> ApplyFilter(IQueryable<AuthorEntity> query, FilterAuthorQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) query = query.Where(x => x.Name.Contains(name));
            return query;
        }
    }
}
