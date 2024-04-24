using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ApplicationDecisions")]
public class ApplicationDecision : AuditBaseEntity
{
    public int ApplicationDecisionId { get; set; }
    public CertificationStatus CertificationStatus { get; set; }
    public DateTimeOffset? RecertificationDate { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}