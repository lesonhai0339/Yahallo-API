using MediatR;

namespace YAHALLO.Application.Commands.MangaViewCommand.Record
{
    public class RecordMangaViewCommand : IRequest<bool>
    {
        public string MangaId { get; set; } = null!;
        public string? ChapterId { get; set; }
        // GUID khách vãng lai (localStorage). Bỏ qua nếu user đã login (lấy UserId từ JWT).
        public string? VisitorId { get; set; }
    }
}
