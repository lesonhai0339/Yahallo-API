//AI generated
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.SubscriptionCommand.Create;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _sender;
        public SubscriptionController(IMediator sender) => _sender = sender;

        [HttpPost]
        [Route("subscription/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JsonResponse<string>>> CreateSubscription(
            [FromBody] CreateSubscriptionCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
