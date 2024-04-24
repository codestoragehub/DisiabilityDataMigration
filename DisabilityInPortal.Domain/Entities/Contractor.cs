using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("Contractors")]
public class Contractor
{
    public int ContractorId { get; set; }

    [StringLength(128)]
    public string LicenseNumber { get; set; }

    [StringLength(512)]
    public string TradeSpecialty { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int? CompanyId { get; set; }
    public Company Company { get; set; }
}