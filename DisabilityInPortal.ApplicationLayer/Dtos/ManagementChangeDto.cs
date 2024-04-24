using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.ManagementChanges.Queries.GetManagementChangeAgreementById;

namespace DisabilityInPortal.ApplicationLayer.Features.ManagementChanges.Queries.GetManagementChangeById;

public class ManagementChangeDto
{
    public int ManagementChangeId { get; set; }
    public bool HasOrIntendToEnterIntoAnyTypeOfAgreement { get; set; }
    public int ApplicationId { get; set; }
    public List<ManagementChangeAgreementDto> ManagementChangeAgreements { get; set; }
}