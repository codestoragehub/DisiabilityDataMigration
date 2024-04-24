using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Models
{
    public class HowDidYouHearAboutUsSetting
    {
        public HowDidYouHearAboutUsType HowDidYouHearAboutUsType { get; set; }
        public bool HasReferredBy { get; set; }
        public string ReferredByTitle { get; set; }
    }
}