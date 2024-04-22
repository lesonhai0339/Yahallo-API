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

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllDeletedPagination
{
    public class GetAllDeletedChapterPaginationQueryHandler : IRequestHandler<GetAllDeletedChapterPaginationQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chaperRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedChapterPaginationQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chaperRepository = chapterRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChapterDto>> Handle(GetAllDeletedChapterPaginationQuery request, CancellationToken cancellationToken)
        {
            var listChapterExists = await _chaperRepository
                           .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (listChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ chương truyện nào");
            }
            return listChapterExists.MapToPagedResult(x => x.MapFullToChapterDto(_mapper));
        }
    }
}
