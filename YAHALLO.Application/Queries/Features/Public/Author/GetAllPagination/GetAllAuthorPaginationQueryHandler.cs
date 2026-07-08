using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAllPagination
{
    public class GetAllAuthorPaginationQueryHandler : IRequestHandler<GetAllAuthorPaginationQuery, PagedResult<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private IMapper _mapper;
        public GetAllAuthorPaginationQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AuthorDto>> Handle(GetAllAuthorPaginationQuery request, CancellationToken cancellationToken)
        {
            var authors= await _authorRepository
                .FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete)&& !x.DeleteDate.HasValue, request.PageNo, request.PageSize, cancellationToken);    
            return authors.MapToPagedResult(x => x.MapToAuthorDto(_mapper));
        }
    }
}
