using dotenv.net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken;
using YAHALLO.Application.Commands.AuthenticationCommand.Login;
using YAHALLO.Application.Commands.UserCommand.Anynomous.ChangePassword;
using YAHALLO.Application.Commands.UserCommand.Anynomous.Create;
using YAHALLO.Application.Commands.UserCommand.Anynomous.Delete;
using YAHALLO.Application.Commands.UserCommand.Anynomous.ForgotPassword;
using YAHALLO.Application.Commands.UserCommand.Anynomous.Restore;
using YAHALLO.Application.Commands.UserCommand.Anynomous.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetAll;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetAllDeleted;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetAllDeletedPagination;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetAllPagination;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetById;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetByIdDeleted;
using YAHALLO.Application.Queries.UserQuery.Anonymous.GetByName;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _Sender;
        public UserController(IMediator sender)
        {
            _Sender = sender;
        }
        [HttpPost]
        [Route("user/check-token-expired")]
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
        [Route("user/forgot-password")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ForgotPassword(
         [FromBody] ForgotPasswordCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("user/change-password")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ChangePassword(
         [FromBody] ChangePasswordCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("user/login")]
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
        [Route("user/create")]
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
        [Route("user/restore")]
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
        [Route("user/update")]
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
        [Route("user/delete")]
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
        [Route("user/get-all")]
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
        [Route("user/get-all-deleted")]
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
        [Route("user/get-all-pagination")]
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
        [Route("user/get-all-deleted-pagination")]
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
        [Route("user/get-by-id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserDto>>> GetById(
           [FromQuery] GetUserByIdQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<UserDto>(result));
        }
        [HttpGet]
        [Route("user/get-by-id-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserDto>>> GetByIdDeleted(
          [FromQuery] GetUserByIdDeleted query,
       CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<UserDto>(result));
        }
        [HttpGet]
        [Route("user/get-by-name")]
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
        [HttpGet]
        [Route("user/filter-user")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<UserDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<UserDto>>>> FilterUser(
            [FromQuery] FilterUserQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<UserDto>>(result));
        }
    }
}
