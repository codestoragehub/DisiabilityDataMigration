

using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum RecommendationType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Deny")]
        Deny = 1,

        [Display(Name = "Certify")]
        Certify = 2,

        [Display(Name = "Further Review")]
        FurtherReview = 3
    }
}
