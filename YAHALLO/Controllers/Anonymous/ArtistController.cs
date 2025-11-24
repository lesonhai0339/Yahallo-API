using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ArtistCommand.Create;
using YAHALLO.Application.Commands.ArtistCommand.Delete;
using YAHALLO.Application.Commands.ArtistCommand.Restore;
using YAHALLO.Application.Commands.ArtistCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.ArtistQuery.FilterArtist;
using YAHALLO.Application.Queries.ArtistQuery.GetAll;
using YAHALLO.Application.Queries.ArtistQuery.GetAllDeleted;
using YAHALLO.Application.Queries.ArtistQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.ArtistQuery.GetAllPagination;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    //[Authorize(Policy = "Admin")]
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
        [HttpPost]
        [Route("artist/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RestoreArtist(
            [FromBody] RestoreArtistCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [Route("artist/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateArtist(
            [FromBody] UpdateArtistCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("artist/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteArtist(
            [FromBody] DeleteArtistCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("artist/get-all")]
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
        [Route("artist/get-all-deleted")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ArtistDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ArtistDto>>>> GetallArtistDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllArtistDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ArtistDto>>(result));
        }
        [HttpGet]
        [Route("artist/get-all-pagination")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ArtistDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ArtistDto>>>> GetallArtistPagination(
           [FromQuery] GetAllArtistPaginationQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ArtistDto>>(result));
        }
        [HttpGet]
        [Route("artist/get-all-deleted-pagination")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ArtistDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ArtistDto>>>> GetallArtistDeletedPagination(
          [FromQuery] GetAllArtistDeletedPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ArtistDto>>(result));
        }
        [HttpGet]
        [Route("artist/filter-artist")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ArtistDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ArtistDto>>>> FilterArtist(
            [FromQuery] FilterArtistQuery query,
            CancellationToken cancellationToken = default)
        {
            var result= await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ArtistDto>>(result));
        }
    }
}
