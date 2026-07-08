//AI generated
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.TagCommand.Create;
using YAHALLO.Application.Commands.TagCommand.Delete;
using YAHALLO.Application.Commands.TagCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Application.Queries.Features.Public.Tag.FilterTag;
using YAHALLO.Application.Queries.Features.Public.Tag.GetAll;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class TagController : ControllerBase
    {
        private readonly IMediator _sender;
        public TagController(IMediator sender) => _sender = sender;

        [HttpGet]
        [Route("tag/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<TagDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<List<TagDto>>>> GetAllTags(CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllTagQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<TagDto>>(result));
        }

        [HttpGet]
        [Route("tag/filter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<TagDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<PagedResult<TagDto>>>> FilterTags(
            [FromQuery] FilterTagQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<TagDto>>(result));
        }

        [HttpPost]
        [Route("tag/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JsonResponse<string>>> CreateTag(
            [FromBody] CreateTagCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut]
        [Route("tag/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateTag(
            [FromBody] UpdateTagCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete]
        [Route("tag/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteTag(
            [FromBody] DeleteTagCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
