//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Create
{
    /// <summary>
    /// Thêm tên khác cho truyện (tên gốc, romaji, tên tiếng Anh…).
    /// Nhận cả DANH SÁCH vì lúc tạo/sửa truyện thường nhập nhiều tên một lần.
    /// </summary>
    public class CreateMangaAssociateNameCommand : IRequest<int>
    {
        public string MangaId { get; set; } = string.Empty;
        public List<string> Names { get; set; } = new List<string>();
    }
}
