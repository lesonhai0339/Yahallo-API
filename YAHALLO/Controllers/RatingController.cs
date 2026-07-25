using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaRatingCommand.Create;
using YAHALLO.Application.Commands.MangaRatingCommand.Delete;
using YAHALLO.Application.Commands.MangaRatingCommand.Restore;
using YAHALLO.Application.Commands.MangaRatingCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Application.Queries.Features.Public.Rating;
using YAHALLO.Application.Queries.Features.Public.Rating.FilterMangaRating;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class RatingController : ControllerBase
    {
        private readonly IMediator _sender;
        public RatingController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("rating/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateArtist(
           [FromBody] CreateRatingCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("rating/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> RestoreArtist(
            [FromBody] RestoreRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPut]
        [Route("rating/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> UpdateArtist(
            [FromBody] UpdateRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpDelete]
        [Route("rating/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteArtist(
            [FromBody] DeleteRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpGet]
        [Route("rating/filter")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<RatingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<RatingDto>>>> FilterRating(
            [FromQuery] FilterRatingQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<RatingDto>>(result));
        }
    }
}
