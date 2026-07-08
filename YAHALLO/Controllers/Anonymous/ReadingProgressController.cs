//AI generated
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ReadingProgressCommand.Upsert;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUser;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUserPagination;
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

        [HttpGet]
        [Route("reading-progress/get-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ReadingProgressDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<PagedResult<ReadingProgressDto>>>> GetProgressPagination(
            [FromQuery] GetReadingProgressByUserPaginationQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ReadingProgressDto>>(result));
        }
    }
}
