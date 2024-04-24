using System;

namespace DisabilityInPortal.Domain.Entities.Common;

public class AuditBaseEntityDto
{
    public DateTimeOffset DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
    public string UpdatedBy { get; set; }
}