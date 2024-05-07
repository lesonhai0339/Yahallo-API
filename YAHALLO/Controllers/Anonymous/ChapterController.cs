using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterCommand.Create;
using YAHALLO.Application.Commands.ChapterCommand.Delete;
using YAHALLO.Application.Commands.ChapterCommand.Restore;
using YAHALLO.Application.Commands.ChapterCommand.Update;
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
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<string>>>> CreateChapter(
          [FromForm] CreateChapterCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponeResult<string>>(result));
        }
        [HttpPost]
        [Route("chapter/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<string>>>> RestoreChapter(
       [FromBody] RestoreChapterCommand command,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponeResult<string>>(result));
        }
        [HttpPut]
        [Route("chapter/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<string>>>> UpdateChapter(
         [FromForm] UpdateChapterCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponeResult<string>>(result));
        }
        [HttpDelete]
        [Route("chapter/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<string>>>> DeleteChapter(
       [FromBody] DeleteChapterCommand command,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponeResult<string>>(result));
        }
    }
}
