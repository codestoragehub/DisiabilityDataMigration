namespace DisabilityInPortal.ApplicationLayer.Features.ManagementChanges.Queries.GetManagementChangeAgreementById;

public class ManagementChangeAgreementDto
{
    public int ManagementChangeAgreementId { get; set; }
    public int ManagementChangeId { get; set; }
    public string Explanation { get; set; }
    public int? DocumentId { get; set; }
    public int ApplicationId { get; set; }
}