using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken;
using YAHALLO.Application.Commands.AuthenticationCommand.Login;
using YAHALLO.Application.Commands.UserCommand.Create;
using YAHALLO.Application.Commands.UserCommand.Delete;
using YAHALLO.Application.Commands.UserCommand.Restore;
using YAHALLO.Application.Commands.UserCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Application.Queries.UserQuery.GetAll;
using YAHALLO.Application.Queries.UserQuery.GetAllDeleted;
using YAHALLO.Application.Queries.UserQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.UserQuery.GetAllPagination;
using YAHALLO.Application.Queries.UserQuery.GetByName;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _Sender;
        public UserController(IMediator sender)
        {
            _Sender = sender;
        }
        [HttpPost]
        [Route("check-token-expired")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoginRespone>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoginRespone>>> CheckToken(
          [FromBody] CheckExpiredTokenCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<LoginRespone>(result));
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoginRespone>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoginRespone>>> Login(
          [FromBody] LoginCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<LoginRespone>(result));
        }
        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateUser(
           [FromBody] CreateUserCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> RestoreUser(
            [FromBody] RestoreUserCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut]
        [Route("update")]
        [AllowAnonymous]
        //[Authorize(Policy = "Normal")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateUser(
           [FromForm] UpdateUserCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteUser(
            [FromBody] DeleteUserCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("get-all")]
        [Authorize(Policy = "Any")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<UserDto>>>> GetAll(
          CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(new GetAllUserQuery(), cancellationToken);
            return Ok(new JsonResponse<List<UserDto>>(result));
        }
        [HttpGet]
        [Route("get-all-deleted")]
        [Authorize(Policy = "Any")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<UserDto>>>> GetAllDeleted(
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(new GetAllUserDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<UserDto>>(result));
        }
        [HttpGet]
        [Route("get-all-pagination")]
        [Authorize(Policy = "Any")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetAllPagination(
            [FromQuery] GetAllPaginationUserQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<UserDto>>(result));
        }
        [HttpGet]
        [Route("get-all-deleted-pagination")]
        [Authorize(Policy = "Any")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> GetAllDeletedPagination(
            [FromQuery] GetAllUserDeletedPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<UserDto>>(result));
        }
        [HttpGet]
        [Route("get-by-name")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<UserDto>>>> GetuserByName(
            [FromQuery] GetUserByNameQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<UserDto>>(result));
        }
    }
}
