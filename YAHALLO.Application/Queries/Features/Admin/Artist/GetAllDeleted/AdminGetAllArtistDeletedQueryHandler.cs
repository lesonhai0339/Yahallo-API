using AutoMapper;
using MediatR;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeleted
{
    public sealed class AdminGetAllArtistDeletedQueryHandler : IRequestHandler<AdminGetAllArtistDeletedQuery, List<AdminArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        public AdminGetAllArtistDeletedQueryHandler(IArtistRepository artistReepository, IMapper mapper)
        {
            _artistRepository = artistReepository;
        }
        public async Task<List<AdminArtistDto>> Handle(AdminGetAllArtistDeletedQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.FindAllSelectAsync(x => x
                .Where(a => !string.IsNullOrEmpty(a.IdUserDelete) && a.DeleteDate.HasValue)
                .Select(t => new AdminArtistDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Birth = t.Birth,
                    Country = t.Countries.GetDescription(),
                    Depscription = t.Depscription,
                    LifeStatus = t.LifeStatus.GetDescription()
                }),
                cancellationToken,
                ignoreQueryFilters: true);
          
            return artists;
        }
    }
}
