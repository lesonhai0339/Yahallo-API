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

namespace YAHALLO.Application.Queries.ArtistQuery.GetAllPagination
{
    public class GetAllArtistPaginationQueryHandler : IRequestHandler<GetAllArtistPaginationQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        public GetAllArtistPaginationQueryHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ArtistDto>> Handle(GetAllArtistPaginationQuery request, CancellationToken cancellationToken)
        {
            var listArtists= await _artistRepository
                .FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (!listArtists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ họa sĩ nào");
            }
            return listArtists.MapToPagedResult(x=> x.MapToArtistDto(_mapper));
        }
    }
}
