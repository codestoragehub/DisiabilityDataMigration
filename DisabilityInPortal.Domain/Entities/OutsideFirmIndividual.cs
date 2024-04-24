using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("OutsideFirmIndividuals")]
public class OutsideFirmIndividual : AuditBaseEntity
{
    public int OutsideFirmIndividualId { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; }

    [StringLength(1024)]
    public string CompanyName { get; set; }

    public ManagementType ManagementType { get; set; }
    public FirmWorkingType FirmWorkingType { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }

    public int ManagementAtOutsideFirmId { get; set; }
    public ManagementAtOutsideFirm ManagementAtOutsideFirm { get; set; }
}