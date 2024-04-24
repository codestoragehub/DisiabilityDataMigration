using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum ManagementType
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Stockholder")]
    Stockholder = 1,

    [Display(Name = "Director")]
    Director = 2,

    [Display(Name = "Officer")]
    Officer = 3
}