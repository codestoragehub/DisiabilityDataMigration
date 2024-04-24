

using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum BussinessStatus
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Started")]
        Started = 1,

        [Display(Name = "Purchased")]
        Purchased = 2,

        [Display(Name = "Acquired")]
        Acquired = 3
    }
}
