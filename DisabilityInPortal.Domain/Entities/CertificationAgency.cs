using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("CertificationAgencies")]
public class CertificationAgency
{
    public CertificationAgency()
    {
        ApplicationCertificationAgencies = new List<ApplicationCertificationAgency>();
        ProfileCertificationAgencies = new List<SupplierProfileCertificationAgency>();
    }

    public int CertificationAgencyId { get; set; }

    [StringLength(256)]
    public string Name { get; set; }

    public bool IsDocumentRequired { get; set; }
    public DocumentType? DocumentType { get; set; }
    public bool IsUsOrganisation { get; set; }
    public bool IsInternationalOrganisation { get; set; }
    public List<ApplicationCertificationAgency> ApplicationCertificationAgencies { get; set; }
    public List<SupplierProfileCertificationAgency> ProfileCertificationAgencies { get; set; }
}