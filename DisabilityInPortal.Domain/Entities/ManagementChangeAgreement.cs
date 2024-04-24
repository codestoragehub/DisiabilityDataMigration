using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("ManagementChangeAgreements")]
public class ManagementChangeAgreement : AuditBaseEntity
{
    public int ManagementChangeAgreementId { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }

    [StringLength(1024)]
    public string Explanation { get; set; }

    public int ManagementChangeId { get; set; }
    public ManagementChange ManagementChange { get; set; }
}