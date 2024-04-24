using DisabilityInPortal.ApplicationLayer.Features.Owners.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviewOtherOwners.Dtos;

public class SiteVisitReviewOtherOwnerDto
{
    public int SiteVisitOtherOwnerId { get; set; }    
    public int OwnerId { get; set; }
    public OwnerDto Owner { get; set; }
    public decimal VotingPercentage { get; set; }
    public int CompanyHistoryAndOwnershipId { get; set; }
    public CompanyHistoryDto CompanyHistoryAndOwnership { get; set; }
    public int SiteVisitReviewId { get; set; }
    public SiteVisitReviewDto SiteVisitReview { get; set; }
}