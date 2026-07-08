using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Country.GetAll
{
    public class GetAllCountryRequestHandler : IRequestHandler<GetAllCountryRequest, List<CountryDto>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetAllCountryRequestHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryDto>> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
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
