using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Keys;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAll
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<GetAllAuthorResult>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICacheService _cacheService;
        private readonly CacheSettings _cacheSettings;
        public  GetAllAuthorQueryHandler(IAuthorRepository authorRepository, ICacheService cacheService, IOptions<CacheSettings> cacheSettings)
        {
            _authorRepository = authorRepository;   
            _cacheService  = cacheService;  
            _cacheSettings = cacheSettings.Value;     
        }
        public async Task<List<GetAllAuthorResult>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var existed = await _cacheService.GetAsync<List<GetAllAuthorResult>>(CacheKeys.Author, cancellationToken);
            if (existed != null)
                return existed;

            var authors = await _authorRepository.FindAllSelectAsync(x => x
                .OrderBy(t => t.Name)
                .Select(t => new GetAllAuthorResult
                {
                    Id = t.Id,
                    Name = t.Name
                }),
                cancellationToken);

            await _cacheService.SetAsync(
                CacheKeys.Author,
                authors,
                TimeSpan.FromMinutes(_cacheSettings.AuthorTtlMinutes),
                cancellationToken);

            return authors;
        }
    }
}
