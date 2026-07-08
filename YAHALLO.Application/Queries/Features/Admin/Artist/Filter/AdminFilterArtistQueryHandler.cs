using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.Filter
{
    public sealed class AdminFilterArtistQueryHandler : IRequestHandler<AdminFilterArtistQuery, PagedResult<AdminArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        public AdminFilterArtistQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<PagedResult<AdminArtistDto>> Handle(AdminFilterArtistQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(t => new AdminArtistDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Birth  = t.Birth    ,
                        Country = t.Countries.GetDescription(),
                        Depscription = t.Depscription ,
                        LifeStatus = t.LifeStatus.GetDescription() ,
                        CreateDate = t.CreateDate,
                        DeleteDate = t.DeleteDate,  
                    }),
                cancellation: cancellationToken,
                ignoreQueryFilters: request.IsDeleted);

            return artists.MapToPagedResult(x => x);
        }
        private IQueryable<ArtistEntity> ApplyFilter(IQueryable<ArtistEntity> filter, AdminFilterArtistQuery request)
        {
            if(!string.IsNullOrEmpty(request.Id)) filter = filter.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) filter = filter.Where(x => x.Name.Contains(name));

            if (request.Country != null) filter = filter.Where(x => x.Countries == request.Country);

            if (request.LifeStatus != null) filter = filter.Where(x => x.LifeStatus == request.LifeStatus);

            if (request.IsDeleted) //deleted items
                filter = filter.Where(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue);

            return filter;
        }
        private IQueryable<ArtistEntity> ApplySorting(IQueryable<ArtistEntity> filter, AdminFilterArtistQuery request)
        {
            return filter.OrderBy(x => x.Id);   
        }
    }
}
