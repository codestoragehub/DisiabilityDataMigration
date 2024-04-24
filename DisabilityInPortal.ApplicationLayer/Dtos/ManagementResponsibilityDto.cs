using System.Collections.Generic;
using DisabilityInPortal.ApplicationLayer.Features.ManagementResponsibility.Queries
    .GetManagementResponsibilityOwnerById;

namespace DisabilityInPortal.ApplicationLayer.Features.ManagementResponsibility.Queries.GetManagementResponsibilityById;

public class ManagementResponsibilityDto
{
    public int ManagementResponsibilityId { get; set; }
    public List<ManagementResponsibilityOwnerDto> ManagementResponsibilityOwners { get; set; }
    public int? OwnerId { get; set; }
    public int ApplicationId { get; set; }
}