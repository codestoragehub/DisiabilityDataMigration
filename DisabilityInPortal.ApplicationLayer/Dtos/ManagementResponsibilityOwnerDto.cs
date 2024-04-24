namespace DisabilityInPortal.ApplicationLayer.Features.ManagementResponsibility.Queries.
    GetManagementResponsibilityOwnerById;

public class ManagementResponsibilityOwnerDto
{
    public int ManagementResponsibilityOwnerId { get; set; }
    public int OwnerId { get; set; }
    public bool? SupervisesDayToDayOperations { get; set; }
    public bool? SupervisesFieldworkProduction { get; set; }
    public bool? HasHiringFiringAuthorityForManagementPersonnel { get; set; }
    public bool? MakesFinancialDecisions { get; set; }
    public bool? HasSigningAuthorityForChecks { get; set; }
    public bool? SignsCosignsForLoansLinesOfCredit { get; set; }
    public bool? ConductsMarketingAndSales { get; set; }
    public bool? IsResponsibleForSigningContracts { get; set; }
    public bool? MakesAndApprovesMajorCapitalExpenses { get; set; }
    public bool? SelectsProjectsOnWhichToBidAndAccept { get; set; }
    public int? DocumentId { get; set; }
    public int ManagementResponsibilityId { get; set; }
    public int ApplicationId { get; set; }
}