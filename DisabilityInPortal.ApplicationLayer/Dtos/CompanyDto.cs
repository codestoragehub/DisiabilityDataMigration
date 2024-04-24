using DisabilityInPortal.ApplicationLayer.Features.Contractors.Queries;
using DisabilityInPortal.ApplicationLayer.Features.Documents.Queries.GetDocumentListByCompanyId;
using DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureById;
using DisabilityInPortal.ApplicationLayer.Features.Users.Queries.GetUserById;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.Companies.Queries.GetCompanyById
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string LegalBusinessName { get; set; }
        public string DoingBusinessAs { get; set; }
        public string FormerCompanyNames { get; set; }
        public string CompanyWebsiteAddress { get; set; }
        public TaxIdType? TaxIdType { get; set; }
        public string FederalTaxId { get; set; }
        public string BusinessAcquisition { get; set; }
        public bool? IsBusinessStartedByCurrentOwnership { get; set; }
        public string BusinessHistory { get; set; }
        public IndustryType? IndustryType { get; set; }
        public string IndustryTypeOther { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsFranchise { get; set; }
        public bool IsContractorCompany { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public ContractorDto Contractor { get; set; }
        public DocumentDto FranchiseAgreementDocument { get; set; }
        public LegalStructureDto LegalStructure { get; set; }
    }
}
