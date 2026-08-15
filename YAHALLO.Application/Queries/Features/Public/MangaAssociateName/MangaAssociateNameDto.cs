//AI Generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.MangaAssociateName
{
    public class MangaAssociateNameDto : IMapFrom<MangaAssociateNameEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MangaId { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaAssociateNameEntity, MangaAssociateNameDto>();
        }
    }
}
