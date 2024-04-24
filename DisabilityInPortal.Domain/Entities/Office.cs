using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("Offices")]
public class Office
{
    public int OfficeId { get; set; }
    public bool IsFirmNamePubliclyDisplayed { get; set; }
    public OfficeSpaceType OfficeSpaceType { get; set; }

    [StringLength(1024)]
    public string OfficeSpaceTypeOther { get; set; }

    public ApplicantOfficeLocation ApplicantOfficeLocation { get; set; }
    public bool HasApplicantSharedSpace { get; set; }

    [StringLength(1024)]
    public string OtherSharingSpaceFirmName { get; set; }

    [StringLength(1024)]
    public string PrimaryBusinessOfOtherFirms { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}