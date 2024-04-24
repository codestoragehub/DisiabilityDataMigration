using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("Managers")]
public class Manager
{
    public int ManagerId { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }

    [StringLength(1024)]
    public string OwnerDuties { get; set; }

    public int OperationAndControlId { get; set; }
    public OperationAndControl OperationAndControl { get; set; }
}