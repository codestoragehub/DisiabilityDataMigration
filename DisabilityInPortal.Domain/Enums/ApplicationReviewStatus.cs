using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum ApplicationReviewStatus
{
    [Display(Name = "Admin Approve")]
    AdminApprove = 1,

    [Display(Name = "Admin Decline")]
    AdminDecline = 2,

    [Display(Name = "Ncc Approve")]
    NccApprove = 3,

    [Display(Name = "Ncc Decline")]
    NccDecline = 4,

    [Display(Name = "Ncc Final Approve")]
    NccFinalApprove = 5,

    [Display(Name = "Ncc Final Decline")]
    NccFinalDecline = 6
}