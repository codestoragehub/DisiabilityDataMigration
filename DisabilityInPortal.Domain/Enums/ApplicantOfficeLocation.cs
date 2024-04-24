using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum ApplicantOfficeLocation
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Home")]
        Home = 1,

        [Display(Name = "Third Party Location")]
        ThirdPartyLocation = 2
    }
}
