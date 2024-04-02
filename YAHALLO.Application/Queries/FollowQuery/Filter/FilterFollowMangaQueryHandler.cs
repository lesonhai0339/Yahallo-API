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
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Application.Queries.FollowQuery.Filter
{
    public class FilterFollowMangaQueryHandler : IRequestHandler<FilterFollowMangaQuery, PagedResult<FollowMangaDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mangaRepository;
        public FilterFollowMangaQueryHandler(IFollowRepository followRepository, IMapper mapper, IUserRepository userRepository, IMangaRepository mangaRepository)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
        }

        public async Task<PagedResult<FollowMangaDto>> Handle(FilterFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var query = _followRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (!string.IsNullOrEmpty(request.MangaId))
            {
                query = query.Where(x=> x.MangaId == request.MangaId);  
            }
            if(!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Join(_userRepository.CreateQueryable(),
                    follow=> follow.UserId,
                    user=> user.Id,
                    (follow, user)=> new {Follow= follow, User= user})
                    .Where(x=> x.User.DisplayName!.Contains(request.UserName) || (x.User.FirstName + x.User.LastName).Contains(request.UserName))
                    .Select(x=> x.Follow);
            }
            if (!string.IsNullOrEmpty(request.MangaName))
            {
                query = query.Join(_mangaRepository.CreateQueryable(),
                    follow => follow.UserId,
                    manga => manga.Id,
                    (follow, manga) => new { Follow = follow, Manga = manga })
                    .Where(x => x.Manga.Name!.Contains(request.MangaName))
                    .Select(x => x.Follow);
            }

            var listFollowMangaExists = await _followRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(listFollowMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bản ghi nào phù hợp yêu cầu");
            }
            return listFollowMangaExists.MapToPagedResult(x => x.MapFullToFollowMangaDto(_mapper));
        }
    }
}
