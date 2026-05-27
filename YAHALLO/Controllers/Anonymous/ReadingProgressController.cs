//AI generated
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ReadingProgressCommand.Upsert;
using YAHALLO.Application.Queries.ReadingProgressQuery;
using YAHALLO.Application.Queries.ReadingProgressQuery.GetByUser;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class ReadingProgressController : ControllerBase
    {
        private readonly IMediator _sender;
        public ReadingProgressController(IMediator sender) => _sender = sender;

        [HttpPost]
        [Route("reading-progress/save")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JsonResponse<string>>> SaveProgress(
            [FromBody] UpsertReadingProgressCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet]
        [Route("reading-progress/get")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ReadingProgressDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<List<ReadingProgressDto>>>> GetProgress(
            [FromQuery] GetReadingProgressByUserQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ReadingProgressDto>>(result));
        }
    }
}
