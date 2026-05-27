//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.MangaTagCommand.Delete
{
    public class DeleteMangaTagCommand : IRequest<string>
    {
        public string MangaId { get; set; } = null!;
        public string TagId { get; set; } = null!;
    }
}
