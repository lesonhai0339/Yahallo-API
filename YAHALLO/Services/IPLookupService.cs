using MaxMind.GeoIP2;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Services
{
    public class IPLookupService: IIPLookupService
    {
        private const string db = "resources\\GeoLite2-City.mmdb";
        private readonly DatabaseReader _reader;    
        public IPLookupService()
        {
            _reader = new DatabaseReader(db);
        }
        public (string? country, string? city) Lookup(string ipAddress)
        {
            try
            {
                var response = _reader.City(ipAddress);
                return (response.Country.Name, response.City.Name);
            }
            catch
            {
                return (string.Empty, string.Empty);
            }
        }
    }
}
