using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Newtonsoft.Json;
using System.Net.Mime;
using YAHALLO.Application.Commands.ChapterImageCommand.Create;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Configuration;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class ChapterImageController: ControllerBase
    {
        private readonly IMediator _sender;
        public ChapterImageController(IMediator sender)
        {
            _sender = sender;   
        }

        [HttpPost]
        [Route("chapter-image/create")]
        [Authorize(Policy = Policies.TransOrAdmin)]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<CreateChapterImageResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public  async Task<ActionResult<JsonResponse<CreateChapterImageResult>>> CreateChapterImage(
            [FromForm] CreateChapterImageCommand command,
            CancellationToken cancellationToken = default
            )
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<CreateChapterImageResult>(result));
        }
    }
}
