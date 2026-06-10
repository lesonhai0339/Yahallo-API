using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.CommentQuery;
using YAHALLO.Application.Queries.MangaQuery;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Application.Repositories;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaRepository : RepositoryBase<MangaEntity, MangaEntity, ApplicationDbContext>, IMangaRepository, IMangaQueryRepository
    {
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public MangaRepository(
            ApplicationDbContext dbContext, 
            IMapper mapper, 
            ICacheService cache) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _cache = cache;
        }
        public async Task<MangaEntity?> FindById(string mangaId, CancellationToken token)
        {
            return await FindAsync(
                        x => x.Id == mangaId && string.IsNullOrEmpty(x.IdUserDelete),
                        queryOptions => queryOptions
                                            .Include(m => m.FollowEntities)
                                            .Include(m => m.ChaptersEntities)
                                            .Include(m => m.ViewCount)
                                            .Include(m => m.RatingEntities),
                        token);
        }
        public async Task<List<MangaSumaryDto>> GetLastUpdateManga(int pageNo, int pageSize, CancellationToken token)
        {
            var connection = _dbContext.Database.GetDbConnection();

            int offset = (pageNo - 1) * pageSize;

            var sql = @"
            SELECT m.Id, m.Name, m.MangaThumbnail, m.MangaBackground, m.LastChapterIndex,
                   m.LastChapterId, m.LastChapterUpdate,
                   ISNULL(v.ViewCount,0) AS TotalViews,
                   (SELECT AVG(CAST(r.Rating AS FLOAT)) FROM MangaRating r WHERE r.MangaId=m.Id) AS AverageRating
            INTO #paged
            FROM Manga m
            LEFT JOIN Counting v ON v.MangaId = m.Id
            WHERE m.IdUserDelete IS NULL AND m.DeleteDate IS NULL
            ORDER BY m.LastChapterUpdate DESC, m.Id DESC
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

            SELECT * FROM #paged
            ORDER BY LastChapterUpdate DESC, Id DESC;

            SELECT mt.MangaId, t.Id, t.Name, t.Description
            FROM MangaTag mt
            INNER JOIN Tag t ON t.Id = mt.TagId
            WHERE mt.MangaId IN (SELECT Id FROM #paged);

            DROP TABLE #paged;
            ";
            //var sql = @"
            // SELECT m.Id, m.Name, m.MangaThumbnail, m.MangaBackground, m.LastChapterIndex, m.LastChapterId, m.LastChapterUpdate,
            //         ISNULL(v.ViewCount, 0) AS TotalViews,
            //         (SELECT CAST(AVG(CAST(r.Rating AS FLOAT)) AS FLOAT) FROM MangaRating r WHERE r.MangaId = m.Id) AS  AverageRating
            //          FROM Manga m
            //          LEFT JOIN Counting v ON v.MangaId = m.Id
            //          WHERE m.IdUserDelete IS NULL
            //          ORDER BY m.LastChapterUpdate DESC, m.Id DESC.
            //          OFFSET @PageNo ROWS FETCH NEXT @PageSize ROWS ONLY

            //SELECT mt.MangaId, t.Id, t.Name, t.Description
            //        FROM MangaTag mt
            //        INNER JOIN Tag t ON t.Id = mt.TagId
            //        WHERE mt.MangaId IN (
            //            SELECT m.Id FROM Manga m
            //            LEFT JOIN Counting v ON v.MangaId = m.Id
            //            WHERE m.IdUserDelete IS NULL  AND m.DeleteDate IS NULL
            //            ORDER BY m.LastChapterUpdate DESC
            //            OFFSET @PageNo ROWS FETCH NEXT @PageSize ROWS ONLY);
            //";

            using var multi = await connection.QueryMultipleAsync(sql, new { Offset = offset, PageSize = pageSize });

            var mangaList = (await multi.ReadAsync<MangaSumaryDto>()).ToList();

            if (!mangaList.Any()) return new List<MangaSumaryDto>();

            var tags = (await multi.ReadAsync<(string MangaId, string Id, string Name, string Description)>()).ToList();

            var tagsByMangaId = tags
                .GroupBy(x => x.MangaId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new TagDto { Id = x.Id, Name = x.Name, Description = x.Description }).ToList()
                );

            foreach (var manga in mangaList)
            {
                manga.Tags = tagsByMangaId.TryGetValue(manga.Id, out var mangaTags)
                    ? mangaTags
                    : new List<TagDto>();
            }

            return mangaList;
        }
        public async Task<MangaDetailDto?> GetMangaDetail(string mangaId, CancellationToken token)
        {
            var connection = _dbContext.Database.GetDbConnection();

            var sql = @"
              -- Manga + aggregated counts
              SELECT m.Id, m.Name, m.Description, m.Level, m.Status,
                     m.Type, m.Countries, m.Season, m.MangaThumbnail, m.MangaBackground, m.UserId,
                     ISNULL(v.ViewCount, 0) AS TotalViews,
                     (SELECT COUNT(*) FROM Follow f WHERE f.MangaId = m.Id AND f.IdUserDelete IS NULL) AS TotalFollows,
                     (SELECT COUNT(*) FROM Chapter c WHERE c.MangaId = m.Id AND c.IdUserDelete IS NULL) AS TotalChapters,
                     (SELECT CAST(AVG(CAST(r.Rating AS FLOAT)) AS FLOAT) FROM MangaRating r WHERE r.MangaId = m.Id) AS
              AverageRating
                      FROM Manga m
                      LEFT JOIN Counting v ON v.MangaId = m.Id
                      WHERE m.Id = @MangaId AND m.IdUserDelete IS NULL;

                      -- Tags
                      SELECT t.Id, t.Name, t.Description
                      FROM MangaTag mt
                      INNER JOIN Tag t ON t.Id = mt.TagId
                      WHERE mt.MangaId = @MangaId;

                      -- Chapters
                      SELECT Id, Title, [Index], CreateDate
                      FROM Chapter
                      WHERE MangaId = @MangaId AND IdUserDelete IS NULL;

                      -- Comments
                      SELECT Id, [Message], CreateDate, IdUserCreate
                      FROM Comment
                      WHERE MangaId = @MangaId AND IdUserDelete IS NULL;

                      -- Authors
                      SELECT a.Id, a.Name
                      FROM MangaAuthor ma
                      INNER JOIN Author a ON a.Id = ma.AuthorId
                      WHERE ma.MangaId = @MangaId;

                      -- Artists
                      SELECT a.Id, a.Name
                      FROM MangaArtist ma
                      INNER JOIN Artist a ON a.Id = ma.ArtistId
                      WHERE ma.MangaId = @MangaId;";

            using var multi = await connection.QueryMultipleAsync(sql, new { MangaId = mangaId });

            var manga = await multi.ReadSingleOrDefaultAsync<MangaDetailDto>();
            if (manga == null) return null;

            manga.Tags = (await multi.ReadAsync<TagDto>()).ToList();
            manga.Chapters = (await multi.ReadAsync<ChapterDto>()).ToList();
            manga.Authors = (await multi.ReadAsync<AuthorDto>()).ToList();
            manga.Artists = (await multi.ReadAsync<ArtistDto>()).ToList();

            return manga;
        }
        public override Task<IPagedResult<MangaEntity>> FindAllAsync(IQueryable<MangaEntity> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default)
        {
            return base.FindAllAsync(
               filterExpression.Include(x => x.LastChapter),
               pageNo,
               pageSize,
               cancellationToken);
        }
    }
}
