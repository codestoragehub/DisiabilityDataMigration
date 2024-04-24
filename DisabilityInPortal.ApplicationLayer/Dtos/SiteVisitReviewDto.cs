using System;
using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.SiteVisitCommitteeReview.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviewOwners.Dtos;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

public class SiteVisitReviewDto
{
    public int SiteVisitReviewId { get; set; }
    public DateTimeOffset? SiteVisitDate { get; set; }
    public string SiteVisitorFirstName { get; set; }
    public string SiteVisitorLastName { get; set; }
    public string AdditionalSiteVisitorName { get; set; }
    public bool IsSiteVisitInPersonOrVirtual { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }
    public List<SiteVisitReviewOwnerDto> SiteVisitReviewOwners { get; set; }

    //Recommendation
    public string ApplicantCompanyVisited { get; set; }
    public RecommendationType Recommendation { get; set; }
    public string RecommendationReasons { get; set; }
    public bool IsOwnershipReview { get; set; }
    public bool IsCapitalExpertiseReview { get; set; }
    public bool IsOperationAndControlReview { get; set; }
    public bool IsEmployeesCompensationReview { get; set; }
    public bool IsOtherSectionReview { get; set; }
    public string OtherReviewSectionName { get; set; }
    public bool IsFormDetailsConfirmed { get; set; }
    public string UserId { get; set; }
    public int ApplicationId { get; set; }
    public OfficeDto Office { get; set; }
    public CompanyHistoryDto CompanyHistoryAndOwnership { get; set; }
    public ContributionOfCapitalAndExpertiseDto ContributionOfCapitalAndExpertise { get; set; }
    public EmployeesCompensationDto EmployeesCompensation { get; set; }
    public List<CommitteeReviewIssueDto> CommitteeReviewIssues { get; set; }
    public OperationAndControlDto OperationAndControl { get; set; }
}