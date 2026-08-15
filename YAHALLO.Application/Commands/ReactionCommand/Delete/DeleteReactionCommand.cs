//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ReactionCommand.Delete
{
    /// <summary>
    /// Xoá mềm một bản ghi cảm xúc theo Id. Người thường chỉ xoá được cảm xúc của
    /// chính mình; mod/admin xoá được của người khác (kiểm tra trong handler).
    /// </summary>
    public class DeleteReactionCommand : IRequest<bool>
    {
        public string Id { get; set; } = string.Empty;
    }
}
