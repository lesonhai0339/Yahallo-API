using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterCommand.Create;
using YAHALLO.Application.Commands.ChapterCommand.Delete;
using YAHALLO.Application.Commands.ChapterCommand.Restore;
using YAHALLO.Application.Commands.ChapterCommand.Update;
using YAHALLO.Application.Commands.RoleCommand.Create;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.ChapterQuery.FilterChapter;
using YAHALLO.Application.Queries.ChapterQuery.GetAll;
using YAHALLO.Application.Queries.ChapterQuery.GetAllDeleted;
using YAHALLO.Application.Queries.ChapterQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.ChapterQuery.GetAllPagination;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Repositories;
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
        [HttpGet]
        [Route("chapter/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<ChapterDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<ChapterDto>>>> GetAllChapter(
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllChapterQuery(), cancellationToken);
            return Ok(new JsonResponse<ResponeResult<ChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponeResult<ChapterDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponeResult<ChapterDto>>>> GetAllChapterDeleted(
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllDeletedChapterQuery(), cancellationToken);
            return Ok(new JsonResponse<ResponeResult<ChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChapterDto>>), StatusCodes.Status201Created)]
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
        [Route("chapter/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChapterDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChapterDto>>>> GetAllDeletedChapterPagination(
        [FromQuery] GetAllDeletedChapterPaginationQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChapterDto>>(result));
        }
        [HttpGet]
        [Route("chapter/filter-chapter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChapterDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChapterDto>>>> FilterChapter(
       [FromQuery] FilterChapterQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChapterDto>>(result));
        }
    }
}
