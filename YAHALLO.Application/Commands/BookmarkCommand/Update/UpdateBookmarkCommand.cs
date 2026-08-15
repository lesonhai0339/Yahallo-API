//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Update
{
    /// <summary>
    /// Sửa tên / mô tả của dấu trang. KHÔNG cho đổi đối tượng được đánh dấu —
    /// đổi sang truyện khác thì bản chất là một dấu trang mới.
    /// </summary>
    public class UpdateBookmarkCommand : IRequest<bool>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Descriptions { get; set; }
    }
}
