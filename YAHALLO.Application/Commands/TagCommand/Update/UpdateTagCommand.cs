//AI generated
using MediatR;

namespace YAHALLO.Application.Commands.TagCommand.Update
{
    public class UpdateTagCommand : IRequest<string>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
