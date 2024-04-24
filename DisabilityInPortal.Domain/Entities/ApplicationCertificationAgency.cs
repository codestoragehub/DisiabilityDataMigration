using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("ApplicationCertificationAgencies")]
public class ApplicationCertificationAgency : AuditBaseEntity
{
    public int ApplicationCertificationAgencyId { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }

    public int CertificationAgencyId { get; set; }
    public CertificationAgency CertificationAgency { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }
}