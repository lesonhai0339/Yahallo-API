using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.RoleCommand.Create;
using YAHALLO.Application.Commands.RoleCommand.Delete;
using YAHALLO.Application.Commands.RoleCommand.Restore;
using YAHALLO.Application.Commands.RoleCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.RoleQuery;
using YAHALLO.Application.Queries.RoleQuery.FilterRole;
using YAHALLO.Application.Queries.RoleQuery.GetAll;
using YAHALLO.Application.Queries.RoleQuery.GetAllDeleted;
using YAHALLO.Application.Queries.RoleQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.RoleQuery.GetAllPagination;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _sender;
        public RoleController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("role/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateRole(
           [FromBody] CreateRoleCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));    
        }
        [HttpPost]
        [Route("role/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RestoreRole(
           [FromBody] RestoreRoleCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [Route("role/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateRole(
           [FromBody] UpdateRoleCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("role/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteRole(
           [FromBody] DeleteRoleCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("role/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<RoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<RoleDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllRoleQuery(), cancellationToken);
            return Ok(new JsonResponse<List<RoleDto>>(result));
        }
        [HttpGet]
        [Route("role/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<RoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<RoleDto>>>> GetAllDeleted(
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllRoleDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<RoleDto>>(result));
        }
        [HttpGet]
        [Route("role/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<RoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<RoleDto>>>> GetAllPagination(
           [FromQuery] GetAllRolePaginationQuery command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<PagedResult<RoleDto>>(result));
        }
        [HttpGet]
        [Route("role/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<RoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<RoleDto>>>> GetAllDeletedPagination(
          [FromQuery] GetAllRoleDeletedPaginationQuery command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<PagedResult<RoleDto>>(result));
        }
        [HttpGet]
        [Route("role/filter-role")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<RoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<RoleDto>>>> FilterRole(
         [FromQuery] FilterRoleQuery command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<PagedResult<RoleDto>>(result));
        }
    }
}
