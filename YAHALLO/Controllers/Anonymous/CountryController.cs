using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.ArtistQuery.GetAllDeleted;
using YAHALLO.Application.Queries.CountryQuery;
using YAHALLO.Application.Queries.CountryQuery.GetAll;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    public class CountryController: ControllerBase
    {
        private readonly IMediator _sender;
        public CountryController(IMediator sender)
        {
            _sender = sender;
        }
        [HttpGet]
        [Route("country/get-all")]
        [AllowAnonymous]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<CountryDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<CountryDto>>>> GetallArtistDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetAllCountryRequest{ }, cancellationToken);
            return Ok(new JsonResponse<List<CountryDto>>(result));
        }
    }
}
