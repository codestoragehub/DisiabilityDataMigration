using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos
{
    public class CompanyHistoryDto
    {
        public int CompanyHistoryAndOwnershipId { get; set; }
        public int CompanyTotalYears { get; set; }
        public BussinessStatus BussinessStatus { get; set; }
        public string CompanyPreviousName { get; set; }
        public int CompanyOwnershipAcquiredYear { get; set; }
        public string WhyStartOrBoughtCompany { get; set; }
        public decimal OwnerCompanyOwnershipPercentage { get; set; }
        public decimal OwnerVotingStockPercentage { get; set; }
        public MajorityOwnerStatus MajorityOwnerStatus { get; set; }
        public string BecomeMajorityOwnerOther { get; set; }
        public string HistoryOwnershipSectionComments { get; set; }
        public int SiteVisitReviewId { get; set; }
    }
}
