//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Create
{
    /// <summary>
    /// Tạo một dấu trang. BookmarkEntity có 3 khoá ngoại nullable
    /// (Manga/Chapter/Blog) — truyền khoá nào thì dấu trang gắn vào thứ đó.
    /// </summary>
    public class CreateBookmarkCommand : IRequest<string>
    {
        public string Name { get; set; } = string.Empty;
        public string? Descriptions { get; set; }

        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? BlogId { get; set; }
    }
}
