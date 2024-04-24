using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("CommitteeReviewIssues")]
public class CommitteeReviewIssue : AuditBaseEntity
{
    public int CommitteeReviewIssueId { get; set; }

    [StringLength(1024)]
    public string Issue { get; set; }

    [StringLength(1024)]
    public string Resolution { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}