using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.CommentCommand.Create;
using YAHALLO.Application.Commands.CommentCommand.Delete;
using YAHALLO.Application.Commands.CommentCommand.Restore;
using YAHALLO.Application.Commands.CommentCommand.Update;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Comment;
using YAHALLO.Application.Queries.Features.Admin.Comment.Filter;
using YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeleted;
using YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeteledPagination;
using YAHALLO.Application.Queries.Features.Public.Comment;
using YAHALLO.Application.Queries.Features.Public.Comment.FilterComment;
using YAHALLO.Application.Queries.Features.Public.Comment.GetAllPagination;
using YAHALLO.Application.Queries.Features.Public.Comment.Load;
using YAHALLO.Application.Queries.Features.Public.Comment.LoadChild;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly IMediator _sender;
        public CommentController(IMediator sender)
        {
            _sender = sender;
        }
        [Authorize]
        [HttpPost]
        [Route("comment/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateComment(
         [FromForm] CreateCommentCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [Authorize]

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
        [Authorize]

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
        [Authorize]

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
        [Route("comment/get-all-deleted")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AdminCommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AdminCommentDto>>>> GetAllcommentDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new AdminGetAllCommentDeletedQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<AdminCommentDto>>(result));
        }
        [HttpGet]
        [Route("comment/get-all-deleted-pagination")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminCommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminCommentDto>>>> GetAllCommentDeletedPagination(
        [FromQuery] AdminGetAllCommentDeletedPaginationQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminCommentDto>>(result));
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

        [HttpGet]
        [Route("comment/admin/filter")]
        //[Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminCommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminCommentDto>>>> AdminFilter(
        [FromQuery] AdminFilterCommentQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminCommentDto>>(result));
        }





        [HttpGet]
        [Route("comment/load")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CommentDto>>>> LoadComment(
        [FromQuery] LoadCommentQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CommentDto>>(result));
        }

        [HttpGet]
        [Route("comment/load-child")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CommentDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CommentDto>>>> LoadChildComment(
        [FromQuery] LoadChildCommentQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CommentDto>>(result));
        }
    }
}
