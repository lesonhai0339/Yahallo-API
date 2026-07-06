//AI generated - added rate limiting
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken;
using YAHALLO.Application.Commands.AuthenticationCommand.Login;
using YAHALLO.Application.Commands.AuthenticationCommand.Logout;
using YAHALLO.Application.Commands.UserCommand.ChangePassword;
using YAHALLO.Application.Commands.UserCommand.Create;
using YAHALLO.Application.Commands.UserCommand.Delete;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Commands.UserCommand.ForgotPassword;
using YAHALLO.Application.Commands.UserCommand.Restore;
using YAHALLO.Application.Commands.UserCommand.Update;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Application.Queries.UserQuery.DTOs;
using YAHALLO.Application.Queries.UserQuery.FilterUser;
using YAHALLO.Application.Queries.UserQuery.GetAll;
using YAHALLO.Application.Queries.UserQuery.GetAllDeleted;
using YAHALLO.Application.Queries.UserQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.UserQuery.GetAllPagination;
using YAHALLO.Application.Queries.UserQuery.GetById;
using YAHALLO.Application.Queries.UserQuery.GetByIdDeleted;
using YAHALLO.Application.Queries.UserQuery.GetByName;
using YAHALLO.Application.Queries.UserQuery.GetMe;
using YAHALLO.Application.Queries.UserQuery.GetNewUserContByDate;
using YAHALLO.Application.Queries.UserQuery.GetProfileById;
using YAHALLO.Application.Queries.UserQuery.GetUserDetail;
using YAHALLO.Application.ResponseTypes;
using YAHALLO.Common;
using YAHALLO.Configuration;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _Sender;
        private readonly AuthCookieOptions _options;
        public UserController(IMediator sender, IOptions<AuthCookieOptions> options)
        {
            _Sender = sender;
            _options = options.Value;
        }
        [HttpPost]
        [Route("user/check-token-expired")]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoginResponse>>> CheckToken(
            [FromBody] CheckExpiredTokenCommand command,
          CancellationToken cancellationToken = default)
        {
            var refresh = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refresh))
                return Unauthorized();

            command.Refeshtoken = refresh;
            var result = await _Sender.Send(command, cancellationToken);
            if(string.IsNullOrEmpty(result.AccessToken) || string.IsNullOrEmpty(result.RefreshToken))
            {
                var opts = new CookieOptions { Domain = _options.Domain, Path = "/" };
                Response.Cookies.Delete("accessToken", opts);
                Response.Cookies.Delete("refreshToken", opts);
                return Unauthorized();
            }
            Response.SetAuthCookie(result.AccessToken, result.RefreshToken, _options);
            return Ok(new JsonResponse<LoginResponse>(result.Info));
        }
        [HttpPost]
        [Route("user/forgot-password")]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
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
        [Authorize]
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
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login(
          [FromBody] LoginCommand command,
          [FromHeader(Name = "X-Client-Type")] string clientType,
          CancellationToken cancellationToken = default)
        {
            var ip = Request.Headers["CF-Connecting-IP"].ToString();
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            }
            var userAgent = Request.Headers["User-Agent"].ToString();

            command.IpAddress = ip;
            command.UserAgent = userAgent;

            var result = await _Sender.Send(command, cancellationToken);
            if(clientType == "web")
            {
                Response.SetAuthCookie(result.AccessToken!, result.RefreshToken!, _options);
                return Ok(new JsonResponse<LoginResponse>(result.Info));
            }
            else
            {
                return Ok(new JsonResponse<AuthResult>(result));
            }

        }
        [HttpPost]
        [Route("user/logout")]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> Logout(
           [FromBody] LogoutCommand command,
           CancellationToken cancellationToken = default)
        {

            var result = await _Sender.Send(command, cancellationToken);
            var opts = new CookieOptions { Domain = _options.Domain, Path = "/" };
            Response.Cookies.Delete("accessToken", opts);
            Response.Cookies.Delete("refreshToken", opts);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPost]
        [Route("user/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<CreateUserResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CreateUserResponseDto>>> CreateUser(
           [FromForm] CreateUserCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<CreateUserResponseDto>(result));
        }
        [HttpPost]
        [Authorize]
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
        [Authorize]
        [Route("user/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UpdateUserResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UpdateUserResult>>> UpdateUser(
           [FromForm] UpdateUserCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<UpdateUserResult>(result));
        }
        [HttpDelete]
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize]
        [Route("user/get-profile")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserProfileDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserProfileDto>>> GetUserProfile(
           [FromQuery] GetProfileByIdRequest query,
        CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<UserProfileDto>(result));
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
        
        [HttpGet]
        [Route("user/detail")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserDetailDto>>> Getme(
            [FromQuery] GetUserDetailQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<UserDetailDto>(result));
        }
        [HttpGet]
        [Route("user/getme")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<MeResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<MeResult>>> Getme(
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(new GetMeQuery { }, cancellationToken);
            return Ok(new JsonResponse<MeResult>(result));
        }
        [HttpGet]
        [Route("user/count")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CountUserQueryResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<CountUserQueryResult>>>> CountUser(
            [FromQuery] CountNewUserQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CountUserQueryResult>>(result));
        }
    }
}
