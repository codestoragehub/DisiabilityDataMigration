using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum CurrencyType
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "USD")]
    Usd = 1
}