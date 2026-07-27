using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterCommand.Create;
using YAHALLO.Application.Commands.ChapterCommand.Delete;
using YAHALLO.Application.Commands.ChapterCommand.Restore;
using YAHALLO.Application.Commands.ChapterCommand.Update;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeleted;
using YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeletedPagination;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Chapter.Filter;
using YAHALLO.Application.Queries.Features.Public.Chapter.GetAllPagination;
using YAHALLO.Application.Queries.Features.Public.Chapter.GetImage;
using YAHALLO.Configuration;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class ChapterController : ControllerBase
    {
        private readonly IMediator _sender;
        public ChapterController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("chapter/create")]
        [Authorize(Policy = Policies.TransOrAdmin)]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateChapter(
          [FromForm] CreateChapterCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("chapter/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> RestoreChapter(
       [FromBody] RestoreChapterCommand command,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpPut]
        [Route("chapter/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> UpdateChapter(
         [FromForm] UpdateChapterCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpDelete]
        [Route("chapter/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> DeleteChapter(
       [FromBody] DeleteChapterCommand command,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
      
        [HttpGet]
        [Route("chapter/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChapterDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChapterDto>>>> GetAllChapterPagination(
        [FromQuery] GetAllChapterPaginationQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/filter-chapter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChapterDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChapterDto>>>> FilterChapter(
       [FromQuery] FilterChapterQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/get-image")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<ChapterDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChapterImageDto>>>> GetAllImage(
         [FromQuery] GetImageQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ChapterImageDto>>(result));
        }

        [HttpGet]
        [Route("chapter/get-all-deleted")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AdminChapterDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AdminChapterDto>>>> GetAllChapterDeleted(
    CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new AdminGetAllDeletedChapterQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<AdminChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/get-all-deleted-pagination")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminChapterDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminChapterDto>>>> GetAllDeletedChapterPagination(
        [FromQuery] AdminGetAllDeletedChapterPaginationQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminChapterDto>>(result));
        }
    }
}
