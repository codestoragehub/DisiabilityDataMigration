using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("SiteVisitReviewOwners")]
public class SiteVisitReviewOwner : AuditBaseEntity
{
    public int SiteVisitReviewOwnerId { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}