using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class ChapterRepository : RepositoryBase<ChapterEntity, ChapterEntity, ApplicationDbContext>, IChapterRepository
    {
        private readonly ApplicationDbContext _dbContext;   
        public ChapterRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
                _dbContext = dbContext;
        }
        //public async Task<List<NewestMangaView>> GetNewestUpdatedMangasAsync(
        //    int pageNo,
        //    int pageSize,
        //    CancellationToken cancellationToken = default)
        //{
        //    var connection = _dbContext.Database.GetDbConnection();

        //    var sql = @"SELECT
        //            c.Id, c.MangaId, c.Title, c.[Index], c.CreateDate,
        //            m.Name, m.Description, m.Level, m.Status,
        //            m.Type, m.Countries, m.Season,
        //            COALESCE(i.CloudUrl, i.BaseUrl) as ThumbnailUrl
        //        FROM Chapter c
        //        INNER JOIN (
        //            SELECT MangaId, MAX(CreateDate) as LatestDate
        //            FROM Chapter
        //            WHERE DeleteDate IS NULL
        //              AND (IdUserDelete IS NULL OR IdUserDelete LIKE '')
        //            GROUP BY MangaId
        //        ) latest ON c.MangaId = latest.MangaId
        //                AND c.CreateDate = latest.LatestDate
        //        INNER JOIN Manga m ON c.MangaId = m.Id
        //            AND (m.IdUserDelete IS NULL OR m.IdUserDelete LIKE '')
        //            AND m.DeleteDate IS NULL
        //        LEFT JOIN Image i ON m.Id = i.MangaId
        //            AND i.ChapterId IS NULL
        //        WHERE c.DeleteDate IS NULL
        //          AND (c.IdUserDelete IS NULL OR c.IdUserDelete LIKE '')
        //        ORDER BY c.CreateDate DESC
        //        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

        //    var result = await connection.QueryAsync<NewestMangaView>(sql, new
        //    {
        //        Offset = (pageNo - 1) * pageSize,
        //        PageSize = pageSize
        //    });

        //    return result.ToList();
        //}
    }
}
