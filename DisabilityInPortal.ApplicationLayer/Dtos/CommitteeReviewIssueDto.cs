namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitCommitteeReview.Dtos;

public class CommitteeReviewIssueDto
{
    public int CommitteeReviewIssueId { get; set; }
    public string Issue { get; set; }
    public string Resolution { get; set; }
    public int SiteVisitReviewId { get; set; }
}