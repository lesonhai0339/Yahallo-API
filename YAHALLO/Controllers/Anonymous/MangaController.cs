using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken;
using YAHALLO.Application.Commands.MangaCommand.Create;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class MangaController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("manga/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateManga(
          [FromForm] CreateMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
