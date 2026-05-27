//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.MangaTagCommand.Create
{
    public class CreateMangaTagCommand : IRequest<string>
    {
        public string MangaId { get; set; } = null!;
        public string TagId { get; set; } = null!;
    }
}
