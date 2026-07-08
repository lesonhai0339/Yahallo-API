using MediatR;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeleted
{
    public sealed class AdminGetAllAuthorDeletedQueryHandler : IRequestHandler<AdminGetAllAuthorDeletedQuery, List<AdminAuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public AdminGetAllAuthorDeletedQueryHandler(IAuthorRepository authorReoisitory)
        {
            _authorRepository = authorReoisitory;
        }
        public async Task<List<AdminAuthorDto>> Handle(AdminGetAllAuthorDeletedQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository
                .FindAllSelectAsync(x => x
                .Where(a => !string.IsNullOrEmpty(a.IdUserDelete) && a.DeleteDate.HasValue)
                .Select(t => new AdminAuthorDto
                {
                    Id = t.Id,
                    Birth    = t.Birth,
                    Country = t.Countries.GetDescription(),
                    Depscription = t.Depscription,
                    LifeStatus = t.LifeStatus.GetDescription(),
                    Name = t.Name
                }),         
                cancellationToken, 
                ignoreQueryFilters: true);
            return authors;
        }
    }
}
