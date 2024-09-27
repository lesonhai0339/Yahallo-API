using AutoMapper;
using FluentValidation.Validators;
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

namespace YAHALLO.Application.Queries.CommentQuery.FilterComment
{
    public class FilterCommentQueryHandler : IRequestHandler<FilterCommentQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mapgaRepository;
        public FilterCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository, IMangaRepository mapgaRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _mapgaRepository = mapgaRepository;
        }
    
        public async Task<PagedResult<CommentDto>> Handle(FilterCommentQuery request, CancellationToken cancellationToken)
        {
            var query = _commentRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Id))
            {
                query =query.Where(x=> x.Id.Equals(request.Id));
            }
            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x=> x.UserId.Equals(request.UserId));   
            }
            if (!string.IsNullOrEmpty(request.MangaId))
            {
                query = query.Where(x => x.CommentType == Domain.Enums.MangaEnums.CommentType.Manga && x.MangaId!.Equals(request.MangaId));
            }
            if(request.DateTime != null)
            {
                query = query.Where(x => x.CreateDate == request.DateTime);
            }
            if (request.IsDateTimeReverser != null)
            {
                if (request.IsDateTimeReverser == true)
                {
                    query = query.OrderByDescending(x => x.CreateDate);
                }
                else
                {
                    query = query.OrderBy(x => x.CreateDate);
                }
            }
            if(request.IsLikeReserver != null)
            {
                if(request.IsLikeReserver == true)
                {
                    query =query.OrderByDescending(x=> x.LikeCount);
                }
                else
                {
                    query = query.OrderBy(x => x.LikeCount);
                }
            }
            if(request.IsNumberChildrenCommentReserver != null)
            {
                if(request.IsNumberChildrenCommentReserver == true)
                {
                    query =query.OrderByDescending(x=> x.CommentCount);
                }
                else
                {
                    query = query.OrderBy(x=> x.CommentCount);
                }
            }
            var listCommentExists= await _commentRepository.FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(! listCommentExists.Any() )
            {
                throw new NotFoundException("Không tìm thấy comment phù hợp yêu cầu");
            }
            return listCommentExists.MapToPagedResult(x => x.MapToCommentDto(_mapper));
        }
    }
}
