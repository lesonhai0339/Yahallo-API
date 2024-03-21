using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ArtistCommand.Create;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _sender;
        public ArtistController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("artist/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateArtist(
            [FromBody] CreateArtistCommand command,
            CancellationToken cancellationToken= default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
