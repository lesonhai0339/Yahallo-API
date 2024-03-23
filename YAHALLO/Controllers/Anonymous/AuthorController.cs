using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ArtistCommand.Create;
using YAHALLO.Application.Commands.AuthorCommand.Create;
using YAHALLO.Application.Commands.AuthorCommand.Delete;
using YAHALLO.Application.Commands.AuthorCommand.Restore;
using YAHALLO.Application.Commands.AuthorCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.AuthorQuery.FilterAuthor;
using YAHALLO.Application.Queries.AuthorQuery.GetAll;
using YAHALLO.Application.Queries.AuthorQuery.GetAllDeleted;
using YAHALLO.Application.Queries.AuthorQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.AuthorQuery.GetAllPagination;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _sender;
        public AuthorController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("author/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateAuthor(
           [FromBody] CreateAuthorCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("author/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RestoreAuthor(
           [FromBody] RestoreAuthorCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [Route("author/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateAuthor(
           [FromBody] UpdateAuthorCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("author/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteAuthor(
           [FromBody] DeleteAuthorCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("author/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AuthorDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AuthorDto>>>> GetAllAuthor(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllAuthorQuery(), cancellationToken);
            return Ok(new JsonResponse<List<AuthorDto>>(result));
        }
        [HttpGet]
        [Route("author/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AuthorDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AuthorDto>>>> GetAllAuthor(
            [FromQuery] GetAllAuthorPaginationQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AuthorDto>>(result));
        }
        [HttpGet]
        [Route("author/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AuthorDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AuthorDto>>>> GetAllAuthorDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllAuthorDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<AuthorDto>>(result));
        }
        [HttpGet]
        [Route("author/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AuthorDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AuthorDto>>>> GetAllAuthorDeletedPagination(
            [FromQuery] GetAllAuthorDeletedPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AuthorDto>>(result));
        }
        [HttpGet]
        [Route("author/filter-author")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AuthorDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AuthorDto>>>> FilterAuthor(
           [FromQuery] FilterAuthorQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AuthorDto>>(result));
        }
    }
}
