using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("Vehicles")]
public class Vehicle : AuditBaseEntity
{
    public int VehicleId { get; set; }

    [StringLength(250)]
    public string VehicleLicensePlateId { get; set; }

    public OwnershipType Ownership { get; set; }

    [StringLength(1024)]
    public string VehicleUsed { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}