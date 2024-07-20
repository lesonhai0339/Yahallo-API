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

namespace YAHALLO.Application.Queries.CommentQuery.GetAll
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, ResponseResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetAllCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;   
        }

        public async Task<ResponseResult<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var listCommentExists = await _commentRepository.FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(listCommentExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ comment nào");
            }
            return new ResponseResult<CommentDto>(listCommentExists.MapToCommentDtoToList(_mapper));  
        }
    }
}
