using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("AdditionalDocuments")]
public class AdditionalDocument : AuditBaseEntity
{
    public int AdditionalDocumentId { get; set; }

    [StringLength(1024)]
    public string Description { get; set; }

    public AdditionalDocumentType Type { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }

    public int AdditionalDocumentListId { get; set; }
    public AdditionalDocumentList AdditionalDocumentList { get; set; }
}