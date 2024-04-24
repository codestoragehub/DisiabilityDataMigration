using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("OperationAndControls")]
public class OperationAndControl
{
    public int OperationAndControlId { get; set; }

    [StringLength(1024)]
    public string OwnerDutiesAndResponsibilities { get; set; }

    public int TimedevoteToBusiness { get; set; }

    [StringLength(1024)]
    public string HowDecisionsMadeWhenOwnerUnavailable { get; set; }

    [StringLength(1024)]
    public string WhoHasFinalWordOnDecision { get; set; }

    [StringLength(1024)]
    public string WhoSupervisesOperations { get; set; }

    [StringLength(1024)]
    public string WhoSupervisesFieldwork { get; set; }

    [StringLength(1024)]
    public string WhoMakesFinancialDecision { get; set; }

    [StringLength(1024)]
    public string WhoConductMarketingSales { get; set; }

    [StringLength(1024)]
    public string WhoResponsibleForSigningContracts { get; set; }

    [StringLength(1024)]
    public string WhoMakesApprovesPurchases { get; set; }

    [StringLength(1024)]
    public string WhoSelectsProjectsToBid { get; set; }

    [StringLength(1024)]
    public string WhoActuallyBiddingAndEstimating { get; set; }

    [StringLength(1024)]
    public string CompanyBiddingOrEstimatingProcedures { get; set; }

    [StringLength(1024)]
    public string WhoHasSignatureAuthority { get; set; }

    public int HowManySignaturesRequired { get; set; }
    public bool IsWorkingForOtherCompany { get; set; }

    [StringLength(1024)]
    public string NameAndTypeOfOtherCompany { get; set; }

    [StringLength(1024)]
    public string TitleAndResponsibilityAtOtherCompany { get; set; }

    [StringLength(1024)]
    public string BusinessPlanForCompanyFuture { get; set; }

    [StringLength(1024)]
    public string OperationSectionComments { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
    public List<Manager> Managers { get; set; }
}