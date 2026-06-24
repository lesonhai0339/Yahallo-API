using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.UserSettingsCommand.Create;
using YAHALLO.Application.Queries.UserSettingsQuery;
using YAHALLO.Application.Queries.UserSettingsQuery.GetById;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
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
        [Route("/user-settings-create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateSettings(
            [FromBody] CreateUserSettingsCommand command, 
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet]
        [Route("/user-settings-get")]
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
