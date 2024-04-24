using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.ApplicationLayer.Features.ApplicationAssignees.Dtos;

public class ApplicationAssigneeDto : AuditBaseEntityDto
{
    public int? ApplicationAssigneeId { get; set; }
    public int ApplicationId { get; set; }
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public int AssignedCount { get; set; }
    public string Roles { get; set; }
    public bool IsAssigned { get; set; }
}