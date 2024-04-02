using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.FollowQuery.GetAllDeleted
{
    public class GetAllDeletedFollowMangaQueryHandler : IRequestHandler<GetAllDeletedFollowMangaQuery, List<FollowMangaDto>>
    {
        private readonly IFollowRepository _followrepository;
        private readonly IMapper _mapper;
        public GetAllDeletedFollowMangaQueryHandler(IFollowRepository followrepository, IMapper mapper)
        {
            _followrepository = followrepository;
            _mapper = mapper;
        }
        public async Task<List<FollowMangaDto>> Handle(GetAllDeletedFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var listFollowMangaExists = await _followrepository
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (listFollowMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bản ghi nào");
            }
            return listFollowMangaExists.MapFullToFollowMangaDtoToList(_mapper);
        }
    }
}
