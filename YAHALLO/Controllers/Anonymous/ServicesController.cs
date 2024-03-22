using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthenticationCommand.CheckExpiredToken;
using YAHALLO.Application.Queries.UserQuery.Anonymous.ComfirmEmail;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Route("services")]
    public class ServicesController : ControllerBase
    {
        private readonly IWebHostEnvironment _evn;
        private readonly IMediator _Sender;
        public ServicesController(IWebHostEnvironment evn, IMediator Sender)
        {
            _Sender = Sender;
            _evn = evn;
        }
        [HttpGet]
        [Route("image")]
        [Produces(MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Gif)]
        public IActionResult Image([FromQuery] string filepath)
        {
            var path = Path.Combine(_evn.ContentRootPath, filepath);
            return PhysicalFile(path, "image/jpeg");
        }
        [HttpGet]
        [Route("confirm-email")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> ConfirmEmail(
                [FromQuery] string token,
                [FromQuery] string userId,
                CancellationToken cancellationToken = default)
        {
            var command = new ConfirmEmailCommand(token: token, userid: userId);
            var result = await _Sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

    }
}
