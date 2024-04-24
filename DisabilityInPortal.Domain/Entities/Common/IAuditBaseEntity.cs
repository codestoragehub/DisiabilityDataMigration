using System;

namespace DisabilityInPortal.Domain.Entities.Common
{
    public interface IAuditBaseEntity
    {
        DateTimeOffset DateCreated { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset? DateUpdated { get; set; }
        string UpdatedBy { get; set; }
    }
}