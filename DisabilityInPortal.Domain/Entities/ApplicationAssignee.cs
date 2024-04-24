using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("ApplicationAssignees")]
public class ApplicationAssignee : AuditBaseEntity
{
    public int ApplicationAssigneeId { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}