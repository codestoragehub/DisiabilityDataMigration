using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileDto
    {
        public int SupplierProfileId { get; set; }
        public List<SupplierProfileCertificationAgencyDto> CertificationAgencies { get; set; }
        public string LegalBusinessName { get; set; }
        public string DoingBusinessAs { get; set; }
        public string FormerCompanyNames { get; set; }
        public string CompanyWebsiteAddress { get; set; }
        public TaxIdType? TaxIdType { get; set; }       
        public string FederalTaxId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsFranchise { get; set; }
        public CerificationType CerificationType { get; set; }
        public int? HowDidYouHearAboutUs { get; set; }
        public string OtherHowDidYouHearAboutUs { get; set; }
        public List<SupplierProfileAddressDto> AddressList { get; set; }
        public SupplierProfileCapabilityDto ProfileCapability { get; set; }
        public decimal NetIncome { get; set; }
        public decimal GrossIncomeLastYear { get; set; }
        public decimal GrossIncome2ndLastYear { get; set; }
        public decimal GrossIncome3rdLastYear { get; set; }
        public int NumberOfEmployees { get; set; }
        public int NumOfYearInBusiness { get; set; }
        public IndustryType IndustryType { get; set; }
        public string IndustryTypeOther { get; set; }
        public string ContractorLicenseNumber { get; set; }
        public string ContractorTradeSpecialty { get; set; }
        public List<SupplierProfileContractReferenceDto> ContractReferenceList { get; set; }
        public EthnicityType PrimaryOwnerEthnicity { get; set; }
        public bool IsPrimaryOwnerLGBTQ { get; set; }
        public string OwnerContactPhone { get; set; }
        public string OwnerContactMobile { get; set; }
        public string OwnerContactEmail { get; set; }
        public string CertificationNumber { get; set; }
        public DateTimeOffset? CertificationDate { get; set; }
        public DateTimeOffset? CertificationExpirationDate { get; set; }
        public string Facebooklink { get; set; }
        public string Twiterlink { get; set; }
        public string VideoLink { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<SupplierProfileLegalStructureDto> LegalStructureList { get; set; }
    }
}
