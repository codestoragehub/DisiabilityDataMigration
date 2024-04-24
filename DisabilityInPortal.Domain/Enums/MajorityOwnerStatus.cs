using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum MajorityOwnerStatus
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "When company started")]
        WhenCompanyStarted = 1,

        [Display(Name = "Other")]
        Other = 2
    }
}
