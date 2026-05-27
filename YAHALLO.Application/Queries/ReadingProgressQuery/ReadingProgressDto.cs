//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ReadingProgressQuery
{
    public class ReadingProgressDto : IMapFrom<ReadingProgressEntity>
    {
        public string MangaId { get; set; } = null!;
        public string ChapterId { get; set; } = null!;
        public int LastPage { get; set; }
        public DateTime LastReadAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReadingProgressEntity, ReadingProgressDto>();
        }
    }
}
