using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.ApplicationLayer.Features.SectionReviews.Queries.GetSectionReviewById;

public class SectionReviewDto
{
    public int SectionReviewId { get; set; }
    public SectionType SectionType { get; set; }
    public bool? DoesSectionPass { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string RoleId { get; set; }
    public ApplicationRole ApplicationRole { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public ReviewType ReviewType { get; set; }
}