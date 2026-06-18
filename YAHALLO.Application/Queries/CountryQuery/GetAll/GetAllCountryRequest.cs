using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.CountryQuery.GetAll
{
    public class GetAllCountryRequest: IRequest<List<CountryDto>>
    {

    }
}
