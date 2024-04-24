using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("Equipments")]
public class Equipment : AuditBaseEntity
{
    public int EquipmentId { get; set; }

    [StringLength(1024)]
    public string EquipmentType { get; set; }

    public OwnershipType Ownership { get; set; }

    [StringLength(1024)]
    public string EquipmentUsed { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}