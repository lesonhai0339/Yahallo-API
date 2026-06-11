using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaCommand.Create;
using YAHALLO.Application.Commands.MangaCommand.Delete;
using YAHALLO.Application.Commands.MangaCommand.Restore;
using YAHALLO.Application.Commands.MangaCommand.Update;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Application.Queries.MangaQuery.FilterManga;
using YAHALLO.Application.Queries.MangaQuery.FilterMangaByTag;
using YAHALLO.Application.Queries.MangaQuery.GetAll;
using YAHALLO.Application.Queries.MangaQuery.GetAllDeleted;
using YAHALLO.Application.Queries.MangaQuery.GetAllDeletedPagination;
using YAHALLO.Application.Queries.MangaQuery.GetAllPagination;
using YAHALLO.Application.Queries.MangaQuery.GetDetail;
using YAHALLO.Application.Queries.MangaQuery.GetHomepage;
using YAHALLO.Application.Queries.MangaQuery.GetTrending;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class MangaController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpGet]
        [Route("manga/homepage")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<HomePageDto>>> GetHomePage(
            CancellationToken cancellationToken= default)
        {
            var result = await _sender.Send(new GetHomepageRequest() , cancellationToken);
            return Ok(new JsonResponse<HomePageDto>(result));
        }

        [HttpPost]
        [Route("manga/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateManga(
          [FromForm] CreateMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("manga/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> RestoreManga(
        [FromBody] RestoreMangaCommand command,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpPut]
        [Route("manga/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> UpdateManga(
         [FromForm] UpdateMangaCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpDelete]
        [Route("manga/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<string>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<string>>>> Deletemanga(
          [FromBody] DeleteMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<ResponseResult<string>>(result));
        }
        [HttpGet]
        [Route("manga/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ResponseResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ResponseResult<MangaDto>>>> GetAllManga(
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllMangaQuery(), cancellationToken);
            return Ok(new JsonResponse<ResponseResult<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<MangaDto>>>> GetAllDeletedManga(
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllMangaDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaDto>>>> GetAllMangaPagination(
            [FromQuery] GetAllMangaPaginationQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaDto>>>> GetAllMangaDeletedPagination(
          [FromQuery] GetAllMangaDeletedPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/filter-manga")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaDto>>>> FilterManga(
          [FromQuery] FilterMangaQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/filter-manga-by-tags")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaDto>>>> FilterMangaByTags(
        [FromQuery] FilterMangaByTagQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaDto>>(result));
        }

        // AI generated — new endpoints
        [HttpGet]
        [Route("manga/trending")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<MangaDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<JsonResponse<List<MangaDto>>>> GetTrendingManga(
            [FromQuery] GetTrendingMangaQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<MangaDto>>(result));
        }
        [HttpGet]
        [Route("manga/detail/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<MangaDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<MangaDetailDto>>> GetMangaDetail(
            string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetMangaDetailRequest { Id = id }, cancellationToken);
            return Ok(new JsonResponse<MangaDetailDto>(result));
        }
    }
}
