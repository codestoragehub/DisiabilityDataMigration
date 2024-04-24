using System;
using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Entities.Common;

public abstract class AuditBaseEntity : IAuditBaseEntity, IBaseEntity
{
    public DateTimeOffset DateCreated { get; set; }

    [StringLength(128)]
    public string CreatedBy { get; set; }

    public DateTimeOffset? DateUpdated { get; set; }

    [StringLength(128)]
    public string UpdatedBy { get; set; }
}