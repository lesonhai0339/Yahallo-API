//AI Generated
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaAssociateNameCommand.Create;
using YAHALLO.Application.Commands.MangaAssociateNameCommand.Delete;
using YAHALLO.Application.Commands.MangaAssociateNameCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.MangaAssociateName;
using YAHALLO.Application.Queries.Features.Public.MangaAssociateName.Filter;
using YAHALLO.Services;

namespace YAHALLO.Controllers
{
    [Authorize]
    public class MangaAssociatenameController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaAssociatenameController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("manga-associate-name/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<int>>> CreateAssociateName(
            [FromBody] CreateMangaAssociateNameCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<int>(result));
        }

        [HttpPut]
        [Route("manga-associate-name/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> UpdateAssociateName(
            [FromBody] UpdateMangaAssociateNameCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpDelete]
        [Route("manga-associate-name/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteAssociateName(
            [FromBody] DeleteMangaAssociateNameCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }

        [HttpGet]
        [Route("manga-associate-name/filter")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaAssociateNameDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaAssociateNameDto>>>> FilterAssociateName(
            [FromQuery] FilterMangaAssociateNameQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaAssociateNameDto>>(result));
        }
    }
}
