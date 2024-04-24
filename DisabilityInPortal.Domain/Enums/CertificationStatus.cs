using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum CertificationStatus
    {
        None = 0,
        [Display(Name = "Approved")]
        Approved = 1,
        [Display(Name = "Declined")]
        Declined = 2,
        [Display(Name = "Further Information")]
        FurtherInformation = 3
    }
}
