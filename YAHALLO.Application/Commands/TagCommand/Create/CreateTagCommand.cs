//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.TagCommand.Create
{
    public class CreateTagCommand : IRequest<string>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
