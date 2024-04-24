using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("LegalStructureDocuments")]
public class LegalStructureDocument
{
    public int LegalStructureDocumentId { get; set; }

    [StringLength(1024)]
    public string Description { get; set; }

    public int? LegalStructureDocumentTypeValue { get; set; }
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int? CompanyId { get; set; }
    public Company Company { get; set; }
    public int LegalStructureId { get; set; }
    public LegalStructure LegalStructure { get; set; }
}