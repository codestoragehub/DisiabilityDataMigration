using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("SiteVisitOtherOwners")]
public class SiteVisitOtherOwner
{
    public int SiteVisitOtherOwnerId { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public decimal VotingPercentage { get; set; }
    public int CompanyHistoryAndOwnershipId { get; set; }
    public CompanyHistoryAndOwnership CompanyHistoryAndOwnership { get; set; }
    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}
