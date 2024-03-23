using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.AuthorQuery.GetAllDeletedPagination
{
    public class GetAllAuthorDeletedPaginationQueryHandler : IRequestHandler<GetAllAuthorDeletedPaginationQuery, PagedResult<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAllAuthorDeletedPaginationQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<AuthorDto>> Handle(GetAllAuthorDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var listAuthors = await _authorRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (!listAuthors.Any())
            {
                throw new NotFoundException("Không tìm thất bất kỳ tác giả nảo");
            }
            return listAuthors.MapToPagedResult(x => x.MapToAuthorDto(_mapper));
        }
    }
}
