using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum OwnershipType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Owned")]
        Owner = 1,

        [Display(Name = "Rent")]
        Tenant = 2
    }
}