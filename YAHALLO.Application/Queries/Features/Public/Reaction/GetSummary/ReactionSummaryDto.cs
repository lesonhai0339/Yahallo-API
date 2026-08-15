//AI Generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Queries.Features.Public.Reaction.GetSummary
{
    public class ReactionSummaryDto
    {
        public string TargetId { get; set; } = string.Empty;
        public ReactionTargetEnum ReactionTo { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        /// <summary>
        /// Cảm xúc của người đang đăng nhập. `null` khi chưa thả, hoặc khi gọi
        /// ẩn danh — client dùng nó để tô sáng nút đang chọn.
        /// </summary>
        public ReactionEnum? MyReaction { get; set; }
    }
}
