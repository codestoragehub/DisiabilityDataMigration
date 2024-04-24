using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("SupplierProfiles", Schema = "sp")]
    public class SupplierProfile : AuditBaseEntity
    {
        public SupplierProfile()
        {
            AddressList = new List<SupplierProfileAddress>();
            ContractReferenceList = new List<SupplierProfileContractReference>();
            LegalStructureList = new List<SupplierProfileLegalStructure>();
            ProfileCapability = new SupplierProfileCapability();
            CertificationAgencies = new List<SupplierProfileCertificationAgency>();
        }
        public int SupplierProfileId { get; set; }
        public List<SupplierProfileCertificationAgency> CertificationAgencies { get; set; }

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
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsFranchise { get; set; }
        public CerificationType CerificationType { get; set; }       
        public int? HowDidYouHearAboutUs { get; set; }

        public string OtherHowDidYouHearAboutUs { get; set; }
        public List<SupplierProfileAddress> AddressList { get; set; }        
        public SupplierProfileCapability ProfileCapability { get; set; }       
        public decimal NetIncome { get; set; }
        public decimal GrossIncomeLastYear { get; set; }
        public decimal GrossIncome2ndLastYear { get; set; }
        public decimal GrossIncome3rdLastYear { get; set; }
        public int NumberOfEmployees { get; set; }
        public int NumOfYearInBusiness { get; set; }
        public IndustryType IndustryType { get; set; }
        public string IndustryTypeOther { get; set; }

        [StringLength(128)]
        public string ContractorLicenseNumber { get; set; }

        [StringLength(512)]
        public string ContractorTradeSpecialty { get; set; }
        public List<SupplierProfileContractReference> ContractReferenceList { get; set; }

        public EthnicityType PrimaryOwnerEthnicity { get; set; }
        public bool IsPrimaryOwnerLGBTQ { get; set; }
        public string OwnerContactPhone { get; set; }       
        public string OwnerContactMobile { get; set; }
        public string OwnerContactEmail { get; set; }

        [StringLength(100)]
        public string CertificationNumber { get; set; }
        public DateTimeOffset? CertificationDate { get; set; }
        public DateTimeOffset? CertificationExpirationDate { get; set; }
        [StringLength(128)]
        public string Facebooklink { get; set; }
        [StringLength(128)]
        public string Twiterlink { get; set; }
        [StringLength(128)]
        public string VideoLink { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public List<SupplierProfileLegalStructure> LegalStructureList { get; set; }

    }
}
