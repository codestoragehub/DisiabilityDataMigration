using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum VeteranStatusType
{
    [Display(Name = "Not a Veteran")]
    NotVeteran = 1,

    [Display(Name = "Veteran With a Disability")]
    Veteran = 2,

    [Display(Name = "Service Disabled Veteran")]
    SDV = 3,

    [Display(Name = "Service Disabled Veteran - VA Verified")]
    SDVVAVerified = 4
}