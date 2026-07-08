using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Commands.MangaCommand.Create;
using YAHALLO.Application.Commands.MangaCommand.Delete;
using YAHALLO.Application.Commands.MangaCommand.DTOs;
using YAHALLO.Application.Commands.MangaCommand.Restore;
using YAHALLO.Application.Commands.MangaCommand.Update;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Manga;
using YAHALLO.Application.Queries.Features.Admin.Manga.Analytics;
using YAHALLO.Application.Queries.Features.Admin.Manga.CountNew;
using YAHALLO.Application.Queries.Features.Admin.Manga.GetAllDeleted;
using YAHALLO.Application.Queries.Features.Admin.Manga.GetAllDeletedPagination;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Manga.FilterManga;
using YAHALLO.Application.Queries.Features.Public.Manga.GetAllPagination;
using YAHALLO.Application.Queries.Features.Public.Manga.GetDetail;
using YAHALLO.Application.Queries.Features.Public.Manga.GetHomepage;
using YAHALLO.Application.Queries.Features.Public.Manga.GetInteraction;
using YAHALLO.Application.Queries.Features.Public.Manga.GetStatus;
using YAHALLO.Application.Queries.Features.Public.Manga.GetTrending;
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
            var result = await _sender.Send(new GetHomepageRequest { } , cancellationToken);
            return Ok(new JsonResponse<HomePageDto>(result));
        }

        [Authorize(Policy = Policies.ModOrAdmin)]
        [HttpPost]
        [Route("manga/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<CreateMangaResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<CreateMangaResponseDto>>> CreateManga(
          [FromForm] CreateMangaCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<CreateMangaResponseDto>(result));
        }
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Authorize(Policy = Policies.ModOrAdmin)]
        [HttpPut]
        [Route("manga/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<UpdateMangaResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<UpdateMangaResponseDto>>> UpdateManga(
         [FromForm] UpdateMangaCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(new JsonResponse<UpdateMangaResponseDto>(result));
        }
        [Authorize(Policy = Policies.ModOrAdmin)]
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
        [Route("manga/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<AdminMangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<AdminMangaDto>>>> GetAllDeletedManga(
        CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new AdminGetAllMangaDeletedQuery { }, cancellationToken);
            return Ok(new JsonResponse<List<AdminMangaDto>>(result));
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
        [ProducesResponseType(typeof(JsonResponse<PagedResult<AdminMangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<AdminMangaDto>>>> GetAllMangaDeletedPagination(
          [FromQuery] AdminGetAllMangaDeletedPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<AdminMangaDto>>(result));
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
        [Route("manga/detail")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<MangaDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<MangaDetailDto>>> GetMangaDetail(
            [FromQuery] GetMangaDetailRequest query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<MangaDetailDto>(result));
        }
        [HttpGet]
        [Route("manga/status")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<MangaStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<MangaStatusDto>>> GetMangaStatus(
            [FromQuery] GetMangaStatusRequest query,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<MangaStatusDto>(result));
        }


        //Admin section

        [HttpGet]
        [Authorize]
        [Route("manga/interaction")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<GetInteractionQueryResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<GetInteractionQueryResult>>> GetInteraction(
           [FromQuery] GetInteractionQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<GetInteractionQueryResult>(result));
        }
        [HttpGet]
        [Route("manga/count")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<CountNewMangaQueryResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<PagedResult<CountNewMangaQueryResult>>>> CountManga(
          [FromQuery] CountNewMangaQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<CountNewMangaQueryResult>>(result));
        }
        [HttpGet]
        [Route("manga/analytics")]
        [Authorize(Policy = Policies.ModOrAdmin)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<GetMangaAnalyticsResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<GetMangaAnalyticsResult>>> MangaAnalytics(
         [FromQuery] GetMangaAnalyticsQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<GetMangaAnalyticsResult>(result));
        }
        [HttpGet]
        [Route("manga/admin/filter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<MangaDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<MangaDto>>>> AdminFilter(
         [FromQuery] FilterMangaQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<MangaDto>>(result));
        }
    }
}
