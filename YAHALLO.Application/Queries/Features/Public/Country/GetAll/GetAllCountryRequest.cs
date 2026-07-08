using MediatR;

namespace YAHALLO.Application.Queries.Features.Public.Country.GetAll
{
    public class GetAllCountryRequest: IRequest<List<CountryDto>>
    {

    }
}
