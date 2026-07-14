using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.UserSettingsCommand.Create;
using YAHALLO.Application.Commands.UserSettingsCommand.Delete;
using YAHALLO.Application.Commands.UserSettingsCommand.Restore;
using YAHALLO.Application.Commands.UserSettingsCommand.Update;
using YAHALLO.Application.Queries.Features.Public.UserSettings;
using YAHALLO.Application.Queries.Features.Public.UserSettings.GetById;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class UserSettingsController: ControllerBase
    {
        private readonly IMediator _sender;
        public UserSettingsController(IMediator sender)
        {
            _sender = sender;   
        }
        [HttpPost]
        [Route("user-settings/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<CreateUserSettingResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CreateUserSettingResult>>> CreateSettings(
            [FromForm] CreateUserSettingsCommand command, 
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<CreateUserSettingResult>(result));
        }
        [HttpPut]
        [Route("user-settings/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UpdateUserSettingResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UpdateUserSettingResult>>> UpdateUserSettings(
           [FromForm] UpdateUserSettingsCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<UpdateUserSettingResult>(result));
        }
        [HttpDelete]
        [Route("user-settings/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteUserSettings(
           [FromBody] DeleteUserSettingsCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("user-settings/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<RestoreUserSettingsResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<RestoreUserSettingsResult>>> RestoreUserSettings(
           [FromBody] RestoreUserSettingsCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<RestoreUserSettingsResult>(result));
        }
        [HttpGet]
        [Route("user-settings/get")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UserSettingsDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UserSettingsDto>>> GetSettings(
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetUserSettingsQuery { }, cancellationToken);
            return Ok(new JsonResponse<UserSettingsDto>(result));
        }
    }
}
