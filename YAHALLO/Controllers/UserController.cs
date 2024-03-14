using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.Create;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _Sender;
        public UserController(IMediator sender) 
        {
            _Sender = sender;
        }
        [HttpPost]
        [Route("user")]
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
    }
}
