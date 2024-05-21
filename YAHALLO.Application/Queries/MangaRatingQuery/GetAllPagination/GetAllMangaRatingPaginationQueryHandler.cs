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

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAllPagination
{
    public class GetAllMangaRatingPaginationQueryHandler : IRequestHandler<GetAllMangaRatingPaginationQuery, PagedResult<MangaRatingDto>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly IMapper _mapper;
        public GetAllMangaRatingPaginationQueryHandler(IMangaRatingRepository mangaRatingRepository, IMapper mapper)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaRatingDto>> Handle(GetAllMangaRatingPaginationQuery request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExists= await _mangaRatingRepository
                .FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if(checkMangaRatingExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy MangaRating nào");
            }
            return checkMangaRatingExists.MapToPagedResult(x=> x.MapFullToMangaRatingDto(_mapper));
        }
    }
}
