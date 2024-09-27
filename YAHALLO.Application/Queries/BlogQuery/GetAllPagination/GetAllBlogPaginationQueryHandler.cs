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

namespace YAHALLO.Application.Queries.BlogQuery.GetAllPagination
{
    public class GetAllBlogPaginationQueryHandler : IRequestHandler<GetAllBlogPaginationQuery, PagedResult<BlogDto>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogPaginationQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<BlogDto>> Handle(GetAllBlogPaginationQuery request, CancellationToken cancellationToken)
        {
            var checkBlogExists= await _blogRepository.FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize,cancellationToken);
            if(checkBlogExists.Count() == 0)
            {
                throw new NotFoundException("Does not exist any Blog");
            }
            return checkBlogExists.MapToPagedResult(x => x.MapToBlogDto(_mapper));
        }
    }
}
