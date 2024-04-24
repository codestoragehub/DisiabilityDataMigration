using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum GeographicalServiceAreaType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Local")]
        Local = 1,

        [Display(Name = "Regional")]
        Regional = 2,

        [Display(Name = "National")]
        National = 3,

        [Display(Name = "International")]
        International = 4
    }
}