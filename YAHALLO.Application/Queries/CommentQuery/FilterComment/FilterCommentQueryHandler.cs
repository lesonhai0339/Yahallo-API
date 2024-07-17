using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
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
    
        public Task<PagedResult<CommentDto>> Handle(FilterCommentQuery request, CancellationToken cancellationToken)
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
                query = query.Where(x => x.CommentType == Domain.Enums.MangaEnums.MangaCommentType.Manga && x.MangaId!.Equals(request.MangaId));
            }
            if(request.DateTime != null)
            {
                if(request.IsDateTimeReverser != null)
                { 
                    if(request.IsDateTimeReverser == true)
                    {
                        query = query.OrderByDescending(x => x.CreateDate);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.CreateDate);
                    }
                }
                else
                {
                    query =query.Where(x=> x.CreateDate == request.DateTime);
                }
            }

            throw new NotImplementedException();
        }
    }
}
