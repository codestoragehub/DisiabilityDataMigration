using System;
using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Entities;

public class Audit
{
    public int AuditId { get; set; }

    [StringLength(256)]
    public string UserId { get; set; }

    [StringLength(256)]
    public string Type { get; set; }

    [StringLength(256)]
    public string TableName { get; set; }

    public DateTimeOffset DateTimeOffset { get; set; }

    [StringLength(1024)]
    public string OldValues { get; set; }

    [StringLength(1024)]
    public string NewValues { get; set; }

    [StringLength(256)]
    public string AffectedColumns { get; set; }

    [StringLength(256)]
    public string PrimaryKey { get; set; }
}