using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("CompanyHistoryAndOwnerships")]
public class CompanyHistoryAndOwnership
{
    public int CompanyHistoryAndOwnershipId { get; set; }
    public int CompanyTotalYears { get; set; }
    public BussinessStatus BussinessStatus { get; set; }

    [StringLength(1024)]
    public string CompanyPreviousName { get; set; }

    public int CompanyOwnershipAcquiredYear { get; set; }

    [StringLength(1024)]
    public string WhyStartOrBoughtCompany { get; set; }

    public decimal OwnerCompanyOwnershipPercentage { get; set; }
    public decimal OwnerVotingStockPercentage { get; set; }
    public MajorityOwnerStatus MajorityOwnerStatus { get; set; }

    [StringLength(1024)]
    public string BecomeMajorityOwnerOther { get; set; }

    [StringLength(1024)]
    public string HistoryOwnershipSectionComments { get; set; }

    public List<SiteVisitOtherOwner> SiteVisitOtherOwners { get; set; }
    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}