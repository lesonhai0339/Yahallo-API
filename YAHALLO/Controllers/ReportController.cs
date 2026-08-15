using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.AuthorCommand.Create;
using YAHALLO.Application.Commands.ReportCommand.Create;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Report;
using YAHALLO.Application.Queries.Features.Public.Report.Filter;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    public class ReportController : ControllerBase
    {
        private readonly IMediator _sender;
        public ReportController(IMediator sender)
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

        [HttpGet]
        [Route("report/filter")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ReportDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ReportDto>>>> FilterReport(
            [FromQuery] FilterReportQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ReportDto>>(result));
        }
    }
}
