using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.FilterChapter
{
    public class FilterChapterQueryHandler : IRequestHandler<FilterChapterQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filter;
        private readonly IMangaRepository _mangaRepository;
        public FilterChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper, IFilters filter, IMangaRepository mangaRepository)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
            _filter = filter;
            _mangaRepository = mangaRepository;
        }

        public async Task<PagedResult<ChapterDto>> Handle(FilterChapterQuery request, CancellationToken cancellationToken)
        {
            var query = _chapterRepository.CreateQueryable();
            query= query.Where(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (request.Index!= null)
            {
                query = query.Where(x => x.Index == request.Index);
            }
            if (!string.IsNullOrEmpty(request.MangaId))
            {
                query = query.Where(x => x.MangaId == request.MangaId);
            }
            if (!string.IsNullOrEmpty(request.MangaName))
            {
                query = query.Join(_mangaRepository.CreateQueryable(),
                    chapter => chapter.MangaId,
                    manga => manga.Id,
                    (chapter, manga) => new { Chapter = chapter, Manga = manga })
                    .Where(x => EF.Functions.Like(x.Manga.Name, request.MangaName))
                    .Select(x => x.Chapter);
            }
            var checkChapterExists = await _chapterRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(checkChapterExists.Count() == 0)
            {
                throw new NotFoundException($"Không tìm thấy chương truyện nào theo yêu cầu");
            }
            return checkChapterExists.MapToPagedResult(x => x.MapFullToChapterDto(_mapper));
        }
    }
}
