using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("Companies")]
public class Company : AuditBaseEntity
{
    public Company()
    {
        Contractor = new Contractor();
        LegalStructureList = new List<LegalStructure>();
    }

    public int CompanyId { get; set; }

    [StringLength(250)]
    public string LegalBusinessName { get; set; }

    [StringLength(200)]
    public string DoingBusinessAs { get; set; }

    [StringLength(250)]
    public string FormerCompanyNames { get; set; }

    [StringLength(500)]
    public string CompanyWebsiteAddress { get; set; }

    public TaxIdType? TaxIdType { get; set; }
    
    [StringLength(128)]
    public string FederalTaxId { get; set; }    
    public BusinessAcquisitionType BusinessAcquisitionType { get; set; }
    public bool? IsBusinessStartedByCurrentOwnership { get; set; }

    [StringLength(1024)]
    public string BusinessHistory { get; set; }

    public IndustryType? IndustryType { get; set; }

    [StringLength(250)]
    public string IndustryTypeOther { get; set; }

    public int? StateId { get; set; }
    public int? CountryId { get; set; }
    public bool? IsFranchise { get; set; }
    public bool IsContractorCompany { get; set; }

    [ForeignKey("StateId")]
    public State State { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }

    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }

    public List<Document> Documents { get; set; }
    public Contractor Contractor { get; set; }
    public List<LegalStructure> LegalStructureList { get; set; }   
}