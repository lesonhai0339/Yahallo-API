using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.MangaQuery.GetHomepage
{
    public class GetHomepageRequestHandler : IRequestHandler<GetHomepageRequest, HomePageDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICacheService _cache;
        private readonly CacheSettings _settings;
        public GetHomepageRequestHandler(
            IOptions<CacheSettings> options,
            IMangaRepository mangaRepository,
            ICacheService cache)
        {
            _settings = options.Value;
            _mangaRepository = mangaRepository;
            _cache = cache;
        }
        public Task<HomePageDto> Handle(GetHomepageRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
