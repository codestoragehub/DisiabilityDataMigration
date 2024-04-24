using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("SiteVisitReviews")]
public class SiteVisitReview : AuditBaseEntity
{
    public SiteVisitReview()
    {
        Office = new Office();
        CompanyHistoryAndOwnership = new CompanyHistoryAndOwnership();
        OperationAndControl = new OperationAndControl();
        ContributionOfCapitalAndExpertise = new ContributionOfCapitalAndExpertise();
        EmployeesCompensation = new EmployeesCompensation();
    }

    public int SiteVisitReviewId { get; set; }
    public DateTimeOffset? SiteVisitDate { get; set; }

    [StringLength(100)]
    public string SiteVisitorFirstName { get; set; }

    [StringLength(100)]
    public string SiteVisitorLastName { get; set; }

    [StringLength(200)]
    public string AdditionalSiteVisitorName { get; set; }

    public bool IsSiteVisitInPersonOrVirtual { get; set; }

    [StringLength(250)]
    public string CompanyName { get; set; }

    [StringLength(1024)]
    public string CompanyAddress { get; set; }

    public List<SiteVisitReviewOwner> SiteVisitReviewOwners { get; set; }

    //Recommendation
    [StringLength(1024)]
    public string ApplicantCompanyVisited { get; set; }

    public RecommendationType Recommendation { get; set; }

    [StringLength(1500)]
    public string RecommendationReasons { get; set; }

    public bool IsOwnershipReview { get; set; }
    public bool IsCapitalExpertiseReview { get; set; }
    public bool IsOperationAndControlReview { get; set; }
    public bool IsEmployeesCompensationReview { get; set; }
    public bool IsOtherSectionReview { get; set; }

    [StringLength(1024)]
    public string OtherReviewSectionName { get; set; }

    public bool IsFormDetailsConfirmed { get; set; }
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public Office Office { get; set; }
    public CompanyHistoryAndOwnership CompanyHistoryAndOwnership { get; set; }
    public OperationAndControl OperationAndControl { get; set; }
    public ContributionOfCapitalAndExpertise ContributionOfCapitalAndExpertise { get; set; }
    public EmployeesCompensation EmployeesCompensation { get; set; }
    public List<CommitteeReviewIssue> CommitteeReviewIssues { get; set; }
}