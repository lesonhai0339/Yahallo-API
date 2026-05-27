//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.ReadingProgressCommand.Upsert
{
    public class UpsertReadingProgressCommand : IRequest<string>
    {
        public string MangaId { get; set; } = null!;
        public string ChapterId { get; set; } = null!;
        public int LastPage { get; set; } = 1;
    }
}
