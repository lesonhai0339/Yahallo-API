//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.Features.Public.Tag.GetAll
{
    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, List<TagDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;

        private const string CacheKey = "tags:all";

        public GetAllTagQueryHandler(ITagRepository tagRepository, IMapper mapper, ICacheService cache)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<TagDto>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
        {
            return await _cache.GetOrSetAsync(
                CacheKey,
                async () =>
                {
                    var tags = await _tagRepository.FindAllAsync(
                        x => string.IsNullOrEmpty(x.IdUserDelete),
                        cancellationToken);
                    return tags.MapToTagDtoList(_mapper);
                },
                TimeSpan.FromMinutes(60),
                cancellationToken);
        }
    }
}
