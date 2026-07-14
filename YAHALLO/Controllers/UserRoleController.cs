using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.UserRoleCommand.Create;
using YAHALLO.Application.Commands.UserRoleCommand.Delete;
using YAHALLO.Application.Commands.UserRoleCommand.Restore;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Admin.UserRole;
using YAHALLO.Application.Queries.Features.Admin.UserRole.GetAllDeleted;
using YAHALLO.Application.Queries.Features.Admin.UserRole.GetAllDeletedPagination;
using YAHALLO.Application.Queries.Features.Public.UserRole;
using YAHALLO.Application.Queries.Features.Public.UserRole.Filter;
using YAHALLO.Application.Queries.Features.Public.UserRole.GetAll;
using YAHALLO.Application.Queries.Features.Public.UserRole.GetAllPagination;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _sender;
        public UserRoleController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("user-role/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateUserRole(
            [FromBody] CreateUserRoleCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("user-role/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RestoreUserRole(
            [FromBody] RestoreUserRoleCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("user-role/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteUserRole(
            [FromBody] DeleteUserRoleCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("user-role/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<UserRoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<UserRoleDto>>>> GetAllUserRole(
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllUserRoleQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<UserRoleDto>>(result));
        }
        [HttpGet]
        [Route("user-role/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AdminUserRoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AdminUserRoleDto>>>> GetAllUserRoleDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new AdminGetAllUserRoleDeletedQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<AdminUserRoleDto>>(result));
        }
        [HttpGet]
        [Route("user-role/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserRoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserRoleDto>>>> GetAllUserRolePagination(
            [FromQuery] GetAllUserRolePagiinationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<UserRoleDto>>(result));
        }
        [HttpGet]
        [Route("user-role/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminUserRoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminUserRoleDto>>>> GetAllUserRoleDeleetedPagination(
           [FromQuery] AdminGetAllUserRoleDeletedPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminUserRoleDto>>(result));
        }
        [HttpGet]
        [Route("user-role/filter-user-role")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserRoleDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserRoleDto>>>> FilterUserRole(
          [FromQuery] FilterUserRoleQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<UserRoleDto>>(result));
        }
    }
}
