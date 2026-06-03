using AutoMapper;
using Elastic.Clients.Elasticsearch;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.MangaQuery.GetAllPagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetNewestUpdateMangaPagination
{
    internal class GetNewestUpdateMangaPaginationQueryHandler : IRequestHandler<GetNewestUpdateMangaPaginationQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IChapterRepository _chapterRepository; 
        private readonly IMapper _mapper;
        public GetNewestUpdateMangaPaginationQueryHandler(IMangaRepository mangaRepository, IChapterRepository chapterRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _chapterRepository = chapterRepository;     
            _mapper = mapper;
        }
        public class ChapterLatest
        {
            public string Id { get; set; }
            public string MangaId { get; set; }
            public string? Title { get; set; }
            public int Index { get; set; }
            public DateTime CreateDate { get; set; }
        }
        public async Task<PagedResult<MangaDto>> Handle(GetNewestUpdateMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            // Thay vì FindBySQLRaw SELECT *
            var latestChapters = await _chapterRepository.QueryRaw<ChapterLatest>(
    @"SELECT c.Id, c.MangaId, c.Title, c.[Index], c.CreateDate
      FROM Chapter c
      WHERE c.DeleteDate IS NULL
        AND (c.IdUserDelete IS NULL OR c.IdUserDelete LIKE '')
        AND c.Id = (
            SELECT TOP 1 c2.Id
            FROM Chapter c2
            WHERE c2.MangaId = c.MangaId
              AND c2.DeleteDate IS NULL
              AND (c2.IdUserDelete IS NULL OR c2.IdUserDelete LIKE '')
            ORDER BY c2.CreateDate DESC
        )
      ORDER BY c.CreateDate DESC
      OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY",
    cancellationToken,
    (request.PageNumber - 1) * request.PageSize,
    request.PageSize);

            if (!latestChapters.Any())
                throw new DataException("No manga found.");

            // Step 2: Get manga + thumbnail
            var mangaIds = latestChapters.Select(x => x.MangaId).ToList();

            var mangas = await _mangaRepository.FindAllAsync(
                filterExpression: x => mangaIds.Contains(x.Id)
                                     && string.IsNullOrEmpty(x.IdUserDelete)
                                     && !x.DeleteDate.HasValue,
                queryOptions: x => x.Include(m => m.Thumbnail),
                cancellationToken: cancellationToken);

            if (!mangas.Any())
                throw new DataException("No manga found.");

            // Step 3: Map
            var mangaLookup = mangas.ToDictionary(x => x.Id);
            var chapterLookup = latestChapters.ToDictionary(x => x.MangaId);


            //return PagedResult<MangaDto>.Create(
            //    totalCount: mangaIds.Count,
            //    pageCount: (int)Math.Ceiling(mangaIds.Count / (double)request.PageSize),
            //    pageSize: request.PageSize,
            //    pageNumber: request.PageNumber,
            //    data: latestChapters
            //        .Select(chapter => mangaLookup[chapter.MangaId]
            //            .MapFullToMangaDto(_mapper, chapter))
            //        .ToList());
            throw new Exception();
        }
    }
}
