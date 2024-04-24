using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("LegalStructures")]
public class LegalStructure
{
    public int LegalStructureId { get; set; }
    public LegalStructureType LegalStructureType { get; set; }

    [StringLength(1024)]
    public string LegalStructureTypeOther { get; set; }

    public int? CompanyId { get; set; }
    public Company Company { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public List<LegalStructureDocument> LegalStructureDocuments { get; set; }
}