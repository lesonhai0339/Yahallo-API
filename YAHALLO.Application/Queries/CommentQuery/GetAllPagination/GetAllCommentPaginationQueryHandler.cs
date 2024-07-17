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

namespace YAHALLO.Application.Queries.CommentQuery.GetAllPagination
{
    public class GetAllCommentPaginationQueryHandler : IRequestHandler<GetAllCommentPaginationQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetAllCommentPaginationQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
    
        public async Task<PagedResult<CommentDto>> Handle(GetAllCommentPaginationQuery request, CancellationToken cancellationToken)
        {
            var listCommentExists= await _commentRepository.FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, 
                request.PageNumber, request.PageSize, cancellationToken);
            if (!listCommentExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ comment nào");
            }
            return listCommentExists.MapToPagedResult(x=> x.MapToCommentDto(_mapper));
        }
    }
}
