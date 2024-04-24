using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("SectionReviews")]
public class SectionReview : AuditBaseEntity
{
    public int SectionReviewId { get; set; }

    public SectionType SectionType { get; set; }

    public bool? DoesSectionPass { get; set; }

    [StringLength(1024)]
    public string Comment { get; set; }

    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }

    public string RoleId { get; set; }

    [ForeignKey("RoleId")]
    public ApplicationRole ApplicationRole { get; set; }

    public int ApplicationId { get; set; }

    public Application Application { get; set; }
    public ReviewType ReviewType { get; set; }
}