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

namespace YAHALLO.Application.Queries.MangaQuery.GetAllPagination
{
    public class GetAllMangaPaginationQueryHandler : IRequestHandler<GetAllMangaPaginationQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public GetAllMangaPaginationQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaDto>> Handle(GetAllMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var listMangaExists = await _mangaRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if(listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ manga nào");
            }
            return listMangaExists.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
