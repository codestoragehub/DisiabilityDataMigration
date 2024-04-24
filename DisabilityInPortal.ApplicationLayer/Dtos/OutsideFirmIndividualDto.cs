using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.ManagementAtOutsideFirm.Queries.GetOutsideFirmIndividualById;

public class OutsideFirmIndividualDto
{
    public int OutsideFirmIndividualId { get; set; }
    public int ManagementAtOutsideFirmId { get; set; }
    public int OwnerId { get; set; }
    public string CompanyName { get; set; }
    public ManagementType ManagementType { get; set; }
    public FirmWorkingType FirmWorkingType { get; set; }
    public int? DocumentId { get; set; }
    public int ApplicationId { get; set; }
}