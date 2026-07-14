//AI generated
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaTagCommand.Create;
using YAHALLO.Application.Commands.MangaTagCommand.Delete;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class MangaTagController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaTagController(IMediator sender) => _sender = sender;

        [HttpPost]
        [Route("manga-tag/add")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JsonResponse<string>>> AddTagToManga(
            [FromBody] CreateMangaTagCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete]
        [Route("manga-tag/remove")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<string>>> RemoveTagFromManga(
            [FromBody] DeleteMangaTagCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
