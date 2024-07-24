using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterCommand.Create;
using YAHALLO.Application.Commands.CommentCommand.Create;
using YAHALLO.Application.Commands.CommentCommand.Delete;
using YAHALLO.Application.Commands.CommentCommand.Restore;
using YAHALLO.Application.Commands.CommentCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.CommentQuery;
using YAHALLO.Application.Queries.CommentQuery.FilterComment;
using YAHALLO.Application.Queries.CommentQuery.GetAll;
using YAHALLO.Application.Queries.CommentQuery.GetAllDeleted;
using YAHALLO.Application.Queries.CommentQuery.GetAllDeteledPagination;
using YAHALLO.Application.Queries.CommentQuery.GetAllPagination;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class CommentController : ControllerBase
    {
        private readonly IMediator _sender;
        public CommentController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("comment/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> CreateComment(
         [FromForm] CreateCommentCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpPost]
        [Route("comment/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> RestoreComment(
           [FromBody] RestoreCommentCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpPut]
        [Route("comment/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> UpdateComment(
            [FromForm] UpdateCommentCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpDelete]
        [Route("comment/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> DeleteComment(
          [FromBody] DeleteCommentCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpGet]
        [Route("comment/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<CommentDto>>>> GetAllComment(
            CancellationToken cancellationToken = default)
        {
            var result= await _sender.Send(new GetAllCommentQuery(),cancellationToken);
            return Ok(new JsonResponse<ResponseResult<CommentDto>>(result));    
        }
        [HttpGet]
        [Route("comment/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<CommentDto>>>> GetAllcommentDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllCommentDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<ResponseResult<CommentDto>>(result));
        }
        [HttpGet]
        [Route("comment/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CommentDto>>>> GetAllCommentPagination(
          [FromQuery] GetAllCommentPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CommentDto>>(result));
        }
        [HttpGet]
        [Route("comment/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CommentDto>>>> GetAllCommentDeletedPagination(
         [FromQuery] GetAllCommentDeletedPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CommentDto>>(result));
        }
        [HttpGet]
        [Route("comment/filter-comment")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CommentDto>>>> FilterComment(
         [FromQuery] FilterCommentQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CommentDto>>(result));
        }
    }
}
