using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum FirmWorkingType
{
    [Display(Name = "None")]
    None = 0,
    
    [Display(Name = "Ownership")]
    Ownership = 1,
    
    [Display(Name = "Employment")]
    Employment = 2
}