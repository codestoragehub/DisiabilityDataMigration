using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("ManagementResponsibilityOwners")]
public class ManagementResponsibilityOwner : AuditBaseEntity
{
    public int ManagementResponsibilityOwnerId { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; }

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
    public Document Document { get; set; }

    public int ManagementResponsibilityId { get; set; }
    public ManagementResponsibility ManagementResponsibility { get; set; }
}