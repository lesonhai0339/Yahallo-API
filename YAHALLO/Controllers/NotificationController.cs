//AI generated
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net.Mime;
using YAHALLO.Application.Commands.NotificationCommand.MarkRead;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Notification;
using YAHALLO.Application.Queries.Features.Public.Notification.GetByUser;
using YAHALLO.Configuration;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _sender;
        public NotificationController(IMediator sender) => _sender = sender;

        [HttpGet]
        [Route("notification/get")]
        [Authorize]
        [EnableRateLimiting(RateLimitingConfiguration.AuthPolicy)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<NotificationDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<PagedResult<NotificationDto>>>> GetNotifications(
            [FromQuery] GetNotificationsByUserQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<NotificationDto>>(result));
        }

        [HttpPut]
        [Route("notification/mark-read")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<string>>> MarkRead(
            [FromBody] MarkNotificationReadCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
