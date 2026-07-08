using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Country;

namespace YAHALLO.Application.Queries.Features.Public.Country.GetAll
{
    public class GetAllCountryRequest: IRequest<List<CountryDto>>
    {

    }
}
