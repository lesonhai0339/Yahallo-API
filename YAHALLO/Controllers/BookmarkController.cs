//AI Generated
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.BookmarkCommand.Create;
using YAHALLO.Application.Commands.BookmarkCommand.Delete;
using YAHALLO.Application.Commands.BookmarkCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Bookmark;
using YAHALLO.Application.Queries.Features.Public.Bookmark.Filter;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    /// <summary>
    /// Dấu trang là dữ liệu riêng tư nên KHÔNG có route nào [AllowAnonymous],
    /// khác Rating/Reaction vốn cho đọc công khai.
    /// </summary>
    [Authorize]
    public class BookmarkController : ControllerBase
    {
        private readonly IMediator _sender;
        public BookmarkController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("bookmark/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateBookmark(
            [FromBody] CreateBookmarkCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut]
        [Route("bookmark/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> UpdateBookmark(
            [FromBody] UpdateBookmarkCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpDelete]
        [Route("bookmark/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteBookmark(
            [FromBody] DeleteBookmarkCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpGet]
        [Route("bookmark/filter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BookmarkDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BookmarkDto>>>> FilterBookmark(
            [FromQuery] FilterBookmarkQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<BookmarkDto>>(result));
        }
    }
}
