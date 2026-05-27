//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Application.Queries.NotificationQuery
{
    public class NotificationDto : IMapFrom<NotificationEntity>
    {
        public required string Id { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? ReferenceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NotificationEntity, NotificationDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));
        }
    }
}
