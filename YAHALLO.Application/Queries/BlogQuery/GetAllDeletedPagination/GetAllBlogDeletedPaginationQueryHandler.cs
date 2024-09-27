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

namespace YAHALLO.Application.Queries.BlogQuery.GetAllDeletedPagination
{
    public class GetAllBlogDeletedPaginationQueryHandler : IRequestHandler<GetAllBlogDeletedPaginationQuery, PagedResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogDeletedPaginationQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<BlogDto>> Handle(GetAllBlogDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var checkBlogExists = await _blogRepository.FindAllAsync(x => !string.IsNullOrWhiteSpace(x.IdUserDelete) && x.DeleteDate.HasValue,request.PageNumber, request.PageSize, cancellationToken);
            if(checkBlogExists.Count() == 0)
            {
                throw new NotFoundException("Does not any blog have deleted");
            }
            return checkBlogExists.MapToPagedResult(x=> x.MapToBlogDto(_mapper));   
        }
    }
}
