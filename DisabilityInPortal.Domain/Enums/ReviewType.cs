using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum ReviewType
{
    [Display(Name = "Admin Review")]
    AdminReview = 1,

    [Display(Name = "Ncc Review")]
    NccReview = 2,
    
    [Display(Name = "Ncc Final Review")]
    NccFinalReview = 3
}