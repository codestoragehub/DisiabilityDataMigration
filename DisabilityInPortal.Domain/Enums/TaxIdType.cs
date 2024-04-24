using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum TaxIdType
    {
        None = 0,

        [Display(Name = "Federal Tax ID")]
        FederalTaxID = 1,

        [Display(Name = "Social Security Number")]
        SocialSecurityNumber = 2
    }
}
