using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading;
using YAHALLO.Application.Commands.ArtistCommand.Create;
using YAHALLO.Application.Queries.Security.Get;
using YAHALLO.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YAHALLO.Controllers.Anonymous
{
    public class Security : Controller
    {
        private readonly IMediator _sender;
        public Security(IMediator sender)
        {
            _sender = sender;
        }
        [HttpGet]
        [Route("security/public")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> GetPublicKey(
            [FromQuery] GetPublicKeyQuery query,
            CancellationToken token = default)
        {
            var result = await _sender.Send(query, token);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
