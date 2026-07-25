using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Keys;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAll
{
    public class GetAllArtistQueryHandler : IRequestHandler<GetAllArtistQuery, List<GetAllArtistResult>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICacheService _cacheService;
        private readonly CacheSettings _cacheSettings;
        public  GetAllArtistQueryHandler(IArtistRepository artistRepository, ICacheService cacheService, IOptions<CacheSettings> cacheSettings)
        {
            _artistRepository = artistRepository;   
            _cacheService = cacheService;   
            _cacheSettings = cacheSettings.Value; 
        }
        public async Task<List<GetAllArtistResult>> Handle(GetAllArtistQuery request, CancellationToken cancellationToken)
        {
            var existed = await _cacheService.GetAsync<List<GetAllArtistResult>>(CacheKeys.Artist, cancellationToken);
            if (existed != null)
                return existed;

            var artists = await _artistRepository.FindAllSelectAsync(x => x
                .OrderBy(t => t.Name)
                .Select(t => new GetAllArtistResult
                {
                    Id  = t.Id, 
                    Name = t.Name
                }),
                cancellationToken);

            await _cacheService.SetAsync(
                CacheKeys.Artist, 
                artists, 
                TimeSpan.FromMinutes(_cacheSettings.ArtistTtlMinutes), 
                cancellationToken);

            return artists;
        }
    }
}
