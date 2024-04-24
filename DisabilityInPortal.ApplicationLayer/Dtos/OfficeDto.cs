using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos
{
    public class OfficeDto
    {
        public int OfficeId { get; set; }
        public bool IsFirmNamePubliclyDisplayed { get; set; }
        public OfficeSpaceType OfficeSpaceType { get; set; }
        public string OfficeSpaceTypeOther { get; set; }
        public ApplicantOfficeLocation ApplicantOfficeLocation { get; set; }
        public bool HasApplicantSharedSpace { get; set; }
        public string OtherSharingSpaceFirmName { get; set; }
        public string PrimaryBusinessOfOtherFirms { get; set; }
        public int SiteVisitReviewId { get; set; }        
    }
}
