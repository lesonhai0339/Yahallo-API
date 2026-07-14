using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaViewCommand.Record;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class MangaViewController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaViewController(IMediator sender)
        {
            _sender = sender;
        }

        // Ghi 1 lượt xem. Cho phép cả khách vãng lai (gửi VisitorId) lẫn user đã login (UserId lấy từ JWT).
        [HttpPost]
        [Route("manga-view/record")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> RecordView(
            [FromBody] RecordMangaViewCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
    }
}
