//AI Generated
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ReactionCommand.Create;
using YAHALLO.Application.Commands.ReactionCommand.Delete;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Reaction;
using YAHALLO.Application.Queries.Features.Public.Reaction.Filter;
using YAHALLO.Application.Queries.Features.Public.Reaction.GetSummary;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class ReactionController : ControllerBase
    {
        private readonly IMediator _sender;
        public ReactionController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("reaction/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> CreateReaction(
            [FromBody] CreateReactionCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpDelete]
        [Route("reaction/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteReaction(
            [FromBody] DeleteReactionCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpGet]
        [Route("reaction/filter")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ReactionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ReactionDto>>>> FilterReaction(
            [FromQuery] FilterReactionQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ReactionDto>>(result));
        }

        [HttpGet]
        [Route("reaction/summary")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ReactionSummaryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ReactionSummaryDto>>> GetReactionSummary(
            [FromQuery] GetReactionSummaryQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<ReactionSummaryDto>(result));
        }
    }
}
