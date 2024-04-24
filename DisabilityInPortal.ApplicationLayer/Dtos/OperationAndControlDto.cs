using DisabilityInPortal.ApplicationLayer.Features.Managers.Dtos;
using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

public class OperationAndControlDto
{
    public int OperationAndControlId { get; set; }
    public string OwnerDutiesAndResponsibilities { get; set; }
    public int TimedevoteToBusiness { get; set; }
    public string HowDecisionsMadeWhenOwnerUnavailable { get; set; }
    public string WhoHasFinalWordOnDecision { get; set; }
    public string WhoSupervisesOperations { get; set; }
    public string WhoSupervisesFieldwork { get; set; }
    public string WhoMakesFinancialDecision { get; set; }
    public string WhoConductMarketingSales { get; set; }
    public string WhoResponsibleForSigningContracts { get; set; }
    public string WhoMakesApprovesPurchases { get; set; }
    public string WhoSelectsProjectsToBid { get; set; }
    public string WhoActuallyBiddingAndEstimating { get; set; }
    public string CompanyBiddingOrEstimatingProcedures { get; set; }
    public string WhoHasSignatureAuthority { get; set; }
    public int HowManySignaturesRequired { get; set; }
    public bool IsWorkingForOtherCompany { get; set; }
    public string NameAndTypeOfOtherCompany { get; set; }
    public string TitleAndResponsibilityAtOtherCompany { get; set; }
    public string BusinessPlanForCompanyFuture { get; set; }
    public string OperationSectionComments { get; set; }
    public int SiteVisitReviewId { get; set; }
    public List<ManagerDto> Managers { get; set; }
}
