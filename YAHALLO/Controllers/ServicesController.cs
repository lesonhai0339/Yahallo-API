using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.UserCommand.ComfirmEmail;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Suggest;
using YAHALLO.Services;

namespace YAHALLO.Controllers
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
            if (string.IsNullOrEmpty(filepath))
            {
                return BadRequest("filepath is required"); // 400
            }
            var p = @"D:\Coding\repos\manga\resources";
            var path = Path.Combine(p, filepath);
            //var path = Path.Combine(_evn.ContentRootPath, filepath);
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

        [HttpGet]
        [Route("search/suggest")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<SuggestResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<SuggestResult>>>> SuggestSearch(
            [FromQuery] GetSuggestQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _Sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<SuggestResult>>(result));
        }

    }
}
