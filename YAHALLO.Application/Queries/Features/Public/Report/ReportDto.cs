//AI Generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.ReportEnums;

namespace YAHALLO.Application.Queries.Features.Public.Report
{
    public class ReportDto : IMapFrom<ReportEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ReportEnumType Type { get; set; }
        /// <summary>Id của đối tượng bị báo cáo — nghĩa của nó phụ thuộc <see cref="Type"/>.</summary>
        public string? Target { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }

        public string? IdUserReport { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatar { get; set; }

        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReportEntity, ReportDto>();
        }
    }
}
