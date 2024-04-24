using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.Countries.Queries.GetCountryById
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Iso2Code { get; set; }
        public string Iso3Code { get; set; }
        public int NumericCode { get; set; }
        public string PhoneCode { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public string Tld { get; set; }
    }
}
