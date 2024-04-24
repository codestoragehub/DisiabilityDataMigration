using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("Countries")]
public class Country
{
    public int CountryId { get; set; }

    [StringLength(256)]
    public string Name { get; set; }

    [StringLength(16)]
    public string Iso2Code { get; set; }

    [StringLength(16)]
    public string Iso3Code { get; set; }

    public int NumericCode { get; set; }

    [StringLength(64)]
    public string PhoneCode { get; set; }

    [StringLength(16)]
    public string Currency { get; set; }

    [StringLength(16)]
    public string CurrencySymbol { get; set; }

    [StringLength(16)]
    public string Tld { get; set; }
}