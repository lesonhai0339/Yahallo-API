//AI Generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Queries.Features.Public.Reaction
{
    public class ReactionDto : IMapFrom<ReactionEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? UserAvatar { get; set; }
        public ReactionEnum Reaction { get; set; }

        // Chỉ MỘT trong bốn khoá dưới đây có giá trị, tuỳ đối tượng được thả cảm xúc.
        public string? BlogId { get; set; }
        public string? CommentId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }

        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReactionEntity, ReactionDto>();
        }
    }
}
