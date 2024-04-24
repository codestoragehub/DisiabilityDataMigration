using DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Commands.CreateSupplierProfile
{
    public class CreateOrUpdateSupplierProfileDto
    {
        public int? SupplierProfileId { get; set; }
        public List<SupplierProfileCertificationAgencyDto> ProfileCertificationAgencies { get; set; }
        public string LegalBusinessName { get; set; }
        public string DoingBusinessAs { get; set; }
        public string FormerCompanyName { get; set; }
        public string CompanyWebsiteAddress { get; set; }
        public TaxIdType? TaxIdType { get; set; }
        public string FederalTaxId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsFranchise { get; set; }
        public CerificationType? CerificationType { get; set; }
        public string PrimaryOwnerContactName { get; set; }
        public string PrimaryOwnerTitle { get; set; }
        public string CompanyContactName { get; set; }
        public string CompanyContactTitle { get; set; }
        public HowDidYouHearAboutUsType HowDidYouHearAboutUs { get; set; }
        public string OtherHowDidYouHearAboutUs { get; set; }
        public List<SupplierProfileAddressDto> AddressList { get; set; }
        public SupplierProfileCapabilityDto? ProfileCapability { get; set; }
        public decimal? NetIncome { get; set; }
        public decimal? GrossIncomeLastYear { get; set; }
        public decimal? GrossIncome2ndLastYear { get; set; }
        public decimal? GrossIncome3rdLastYear { get; set; }
        public int? NumberOfEmployees { get; set; }
        public int? NumOfYearInBusiness { get; set; }
        public IndustryType IndustryType { get; set; }
        public string IndustryTypeOther { get; set; }
        public string ContractorLicenseNumber { get; set; }
        public string ContractorTradeSpecialty { get; set; }
        public List<SupplierProfileContractReferenceDto> ContractReferenceList { get; set; }
        public List<SupplierProfileLegalStructureDto> LegalStructureList { get; set; }
        public string UserId { get; set; }
    }
}
