using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllDeleted
{
    public class GetAllCommentDeletedQueryHandler : IRequestHandler<GetAllCommentDeletedQuery, ResponseResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetAllCommentDeletedQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
    
        public async Task<ResponseResult<CommentDto>> Handle(GetAllCommentDeletedQuery request, CancellationToken cancellationToken)
        {
            var listCommentExists= await _commentRepository.FindAllAsync(x=> !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);    
            if(listCommentExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy comment nào bị xóa");
            }
            return new ResponseResult<CommentDto>(listCommentExists.MapToCommentDtoToList(_mapper));
        }
    }
}
