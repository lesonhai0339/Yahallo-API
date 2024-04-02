using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.FollowQuery.GetAll
{
    public class GetAllFollowMangaQueryHandler : IRequestHandler<GetAllFollowMangaQuery, List<FollowMangaDto>>
    {
        private readonly IFollowRepository _followrepository;
        private readonly IMapper _mapper;
        public GetAllFollowMangaQueryHandler(IFollowRepository followrepository, IMapper mapper)
        {
            _followrepository = followrepository;
            _mapper = mapper;
        }
        public async Task<List<FollowMangaDto>> Handle(GetAllFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var listFollowMangaExists = await _followrepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(listFollowMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ bản ghi nào");
            }
            return listFollowMangaExists.MapFullToFollowMangaDtoToList(_mapper);
        }
    }
}
