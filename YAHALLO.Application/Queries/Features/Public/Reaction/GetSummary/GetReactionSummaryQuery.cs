//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Queries.Features.Public.Reaction.GetSummary
{
    /// <summary>
    /// Số like/dislike của MỘT đối tượng, kèm cảm xúc của người đang đăng nhập.
    /// Đây là thứ nút like/dislike cần — dùng `filter` rồi tự đếm ở client sẽ phải
    /// kéo về toàn bộ bản ghi.
    /// </summary>
    public class GetReactionSummaryQuery : IRequest<ReactionSummaryDto>
    {
        public string TargetId { get; set; } = string.Empty;
        public ReactionTargetEnum ReactionTo { get; set; }
    }
}
