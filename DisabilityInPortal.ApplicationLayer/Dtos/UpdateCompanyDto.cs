using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.ApplicationLayer.Features.Contractors.Queries;
using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.ApplicationLayer.Features.Documents.Queries.GetDocumentListByCompanyId;
using DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureById;

namespace DisabilityInPortal.ApplicationLayer.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyDto
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
        public bool IsContractorCompany { get; set; }        
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsFranchise { get; set; }
        public string UserId { get; set; }
        public ContractorDto Contractor { get; set; }
        public DocumentDto FranchiseAgreementDocument { get; set; }
        public LegalStructureDto LegalStructure { get; set; }
    }
}
