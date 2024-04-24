using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum FacilityType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Principal Place of Business")]
        PrincipalPlaceOfBusiness = 1,

        [Display(Name = "Additional Office")]
        AdditionalOffice = 2,

        [Display(Name = "Plant")]
        Plant = 3,

        [Display(Name = "Storage")]
        Storage = 4,

        [Display(Name = "Warehouse")]
        Warehouse = 5,

        [Display(Name = "Distribution Center")]
        DistributionCenter = 6
    }
}