using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAllPagination
{
    public class GetAllAuthorPaginationQueryHandler : IRequestHandler<GetAllAuthorPaginationQuery, PagedResult<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAllAuthorPaginationQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<PagedResult<AuthorDto>> Handle(GetAllAuthorPaginationQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q => q
                    .Select(x => new AuthorDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Depscription = x.Depscription,
                        Birth = x.Birth,
                        Countries = x.Countries,
                        LifeStatus = x.LifeStatus
                    }),
                cancellationToken
                );
            return authors.MapToPagedResult(x => x);
        }
    }
}
