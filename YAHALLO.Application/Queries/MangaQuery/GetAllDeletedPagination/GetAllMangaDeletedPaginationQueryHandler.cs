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

namespace YAHALLO.Application.Queries.MangaQuery.GetAllDeletedPagination
{
    public class GetAllMangaDeletedPaginationQueryHandler : IRequestHandler<GetAllMangaDeletedPaginationQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public GetAllMangaDeletedPaginationQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<MangaDto>> Handle(GetAllMangaDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var listMangaExists = await _mangaRepository
                           .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSizee, cancellationToken);
            if (listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ manga nào");
            }
            return listMangaExists.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
