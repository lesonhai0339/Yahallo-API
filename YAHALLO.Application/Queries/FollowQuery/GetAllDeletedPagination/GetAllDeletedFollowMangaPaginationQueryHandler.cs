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

namespace YAHALLO.Application.Queries.FollowQuery.GetAllDeletedPagination
{
    public class GetAllDeletedFollowMangaPaginationQueryHandler : IRequestHandler<GetAllDeletedFollowMangaPaginationQuery, PagedResult<FollowMangaDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedFollowMangaPaginationQueryHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<FollowMangaDto>> Handle(GetAllDeletedFollowMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var listFollowMangaExists = await _followRepository
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue,
                            request.PageNumber, request.PageSize, cancellationToken);
            if (listFollowMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bản ghi nào");
            }
            return listFollowMangaExists.MapToPagedResult(x => x.MapFullToFollowMangaDto(_mapper));
        }
    }
}
