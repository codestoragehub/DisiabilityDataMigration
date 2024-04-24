using DisabilityInPortal.ApplicationLayer.Features.Owners.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviewOwners.Dtos;

public class SiteVisitReviewOwnerDto
{
    public int SiteVisitReviewOwnerId { get; set; }
    public int SiteVisitReviewId { get; set; }
    public SiteVisitReviewDto SiteVisitReview { get; set; }
    public int OwnerId { get; set; }
    public OwnerDto Owner { get; set; }
}