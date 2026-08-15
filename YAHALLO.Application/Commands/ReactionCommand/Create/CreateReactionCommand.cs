//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    /// <summary>
    /// Đặt cảm xúc của người dùng hiện tại lên một đối tượng.
    /// Hành vi là UPSERT + TOGGLE: chưa có thì tạo, khác loại thì đổi, bấm lại
    /// đúng loại đang có thì gỡ — giống nút like/dislike thông thường.
    /// </summary>
    public class CreateReactionCommand : IRequest<bool>
    {
        public string TargetId { get; set; } = string.Empty;
        public ReactionTargetEnum ReactionTo { get; set; }
        public ReactionEnum? Reaction { get; set; }
    }
}
