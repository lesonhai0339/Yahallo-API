using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterCommand.Create;
using YAHALLO.Application.Commands.RoleCommand.Create;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class ChapterController : ControllerBase
    {
        private readonly IMediator _sender;
        public ChapterController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("chapter/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult>>> CreateChapter(
          [FromForm] CreateChapterCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponeResult>(result));
        }
    }
}
