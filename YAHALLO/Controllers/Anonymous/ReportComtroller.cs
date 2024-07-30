using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthorCommand.Create;
using YAHALLO.Application.Commands.ReportCommand.Create;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class ReportComtroller : ControllerBase
    {
        private readonly IMediator _sender;
        public ReportComtroller(IMediator sender)
        {
            _sender = sender;
        }
        [HttpPost]
        [Route("Create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> CreateReport(
           [FromForm] CreateReportCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
    }
}
