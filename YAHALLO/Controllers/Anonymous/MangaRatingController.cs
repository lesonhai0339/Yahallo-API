using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaRatingCommand.Create;
using YAHALLO.Application.Commands.MangaRatingCommand.Delete;
using YAHALLO.Application.Commands.MangaRatingCommand.Restore;
using YAHALLO.Application.Commands.MangaRatingCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.ArtistQuery.GetAll;
using YAHALLO.Application.Queries.MangaRatingQuery;
using YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class MangaRatingController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaRatingController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("rating/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> CreateArtist(
           [FromBody] CreateMangaRatingCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPost]
        [Route("rating/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> RestoreArtist(
            [FromBody] RestoreMangaRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPut]
        [Route("rating/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> UpdateArtist(
            [FromBody] UpdateMangaRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpDelete]
        [Route("rating/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteArtist(
            [FromBody] DeleteMangaRatingCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpGet]
        [Route("rating/get-all")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ArtistDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ArtistDto>>>> GetallArtist(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllArtistQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ArtistDto>>(result));
        }
        [HttpGet]
        [Route("rating/filter")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaRatingDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaRatingDto>>>> FilterRating(
            [FromQuery] FilterMangaRatingQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaRatingDto>>(result));
        }
    }
}
