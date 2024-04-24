using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.ManagementAtOutsideFirm.Queries.GetOutsideFirmIndividualById;

namespace DisabilityInPortal.ApplicationLayer.Features.ManagementAtOutsideFirm.Queries.GetManagementAtOutsideFirmById;

public class ManagementAtOutsideFirmDto
{
    public int ManagementAtOutsideFirmId { get; set; }
    public bool? HasAnyManagementOutsideAtFirm { get; set; }
    public List<OutsideFirmIndividualDto> OutsideFirmIndividuals { get; set; }
    public int ApplicationId { get; set; }
}