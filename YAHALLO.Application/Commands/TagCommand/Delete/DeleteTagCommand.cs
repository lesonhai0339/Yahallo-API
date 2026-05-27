//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.TagCommand.Delete
{
    public class DeleteTagCommand : IRequest<string>
    {
        public string Id { get; set; } = null!;
    }
}
