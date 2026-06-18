using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.CountryQuery.GetAll
{
    public class GetAllCountryRequestHandler : IRequestHandler<GetAllCountryRequest, IReadOnlyList<CountryDto>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetAllCountryRequestHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IReadOnlyList<CountryDto>> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
        {
            var countries = await _countryRepository.FindAllSelectAsync(x => x
                .Select(x => new CountryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    FullName = x.FullName,
                    VietnameseName = x.VietnameseName,
                    Code = x.Code,
                    FaxCode = x.FaxCode,
                    PhoneCode = x.PhoneCode,
                }),
                cancellationToken);

            return countries;
        }
    }
}
