using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.SectionReviews.Commands.CreateSectionReview;

public class CreateOrUpdateSectionReviewDto
{
    public int? SectionReviewId { get; set; }
    public SectionType SectionType { get; set; }
    public bool? DoesSectionPass { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public string RoleId { get; set; }
    public int ApplicationId { get; set; }
    public ReviewType ReviewType { get; set; }
}