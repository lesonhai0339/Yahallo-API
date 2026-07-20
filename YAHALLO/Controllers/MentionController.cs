using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net.Mime;
using YAHALLO.Application.Commands.ArtistCommand.Create;
using YAHALLO.Application.Commands.Mention.Update;
using YAHALLO.Configuration;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class MentionController : ControllerBase
    {
        private readonly IMediator _sender;
        public MentionController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("mention/update")]
        [Authorize]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> UpdateMention(
            [FromBody] UpdateMentionCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
    }
}
