using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.FollowCommand.Create;
using YAHALLO.Application.Commands.FollowCommand.Delete;
using YAHALLO.Application.Commands.FollowCommand.Restore;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Follow;
using YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeleted;
using YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeletedPagination;
using YAHALLO.Application.Queries.FollowQuery;
using YAHALLO.Application.Queries.FollowQuery.Filter;
using YAHALLO.Application.Queries.FollowQuery.GetAll;
using YAHALLO.Application.Queries.FollowQuery.GetAllPagination;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class FollowController : ControllerBase
    {
        private readonly IMediator _sender;
        public FollowController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("follow-manga/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateFollowManga(
           [FromBody] CreateFollowMangaCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("follow-manga/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> RestoreFollowManga(
          [FromBody] RestoreFollowMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpDelete]
        [Route("follow-manga/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteFollowManga(
          [FromBody] DeleteFollowMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("follow-manga/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<FollowMangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<FollowMangaDto>>>> GetAllFollowManga(
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllFollowMangaQuery(), cancellationToken);
            return Ok(new JsonResponse<List<FollowMangaDto>>(result));
        }
      
        [HttpGet]
        [Route("follow-manga/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<FollowMangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<FollowMangaDto>>>> GetAllFollowMangaPagination(
            [FromQuery] GetAllFollowMangaPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<FollowMangaDto>>(result));
        }
        [HttpGet]
        [Route("follow-manga/filter-follow-manga")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<FollowMangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<FollowMangaDto>>>> FilterFollowManga(
          [FromQuery] FilterFollowMangaQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<FollowMangaDto>>(result));
        }

        [HttpGet]
        [Route("follow-manga/get-all-deleted")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AdminFollowDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AdminFollowDto>>>> GetAllDeletedFollowManga(
      CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllDeletedFollowMangaQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<AdminFollowDto>>(result));
        }
        [HttpGet]
        [Route("follow-manga/get-all-deleted-pagination")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminFollowDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminFollowDto>>>> GetAllDeletedFollowMangaPagination(
          [FromQuery] GetAllDeletedFollowMangaPaginationQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminFollowDto>>(result));
        }
    }
}
