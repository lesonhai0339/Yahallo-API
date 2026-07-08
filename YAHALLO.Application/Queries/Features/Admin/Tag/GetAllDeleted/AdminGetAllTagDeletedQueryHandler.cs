using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Tag.GetAllDeleted
{
    public sealed class AdminGetAllTagDeletedQueryHandler : IRequestHandler<AdminGetAllTagDeletedQuery, List<AdminTagDto>>
    {
        private readonly ITagRepository _tagRepository;
        public AdminGetAllTagDeletedQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<AdminTagDto>> Handle(AdminGetAllTagDeletedQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository
                .FindAllSelectAsync(x => x
                    .Where(t => !string.IsNullOrEmpty(t.IdUserDelete) && t.DeleteDate.HasValue)
                    .Select(x => new AdminTagDto
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Name = x.Name
                    }),
                    cancellationToken,
                    ignoreQueryFilters: true);
            return tags;
        }
    }
} 
