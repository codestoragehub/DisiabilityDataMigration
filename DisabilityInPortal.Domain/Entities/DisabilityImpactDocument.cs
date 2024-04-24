using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("DisabilityImpactDocuments")]
public class DisabilityImpactDocument : AuditBaseEntity
{
    public int DisabilityImpactDocumentId { get; set; }

    [StringLength(1024)]
    public string Description { get; set; }

    public DisabilityImpactDocumentType DisabilityImpactDocumentType { get; set; }
    public int ApplicationId { get; set; }
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int DisabilityImpactId { get; set; }
    public DisabilityImpact DisabilityImpact { get; set; }
}