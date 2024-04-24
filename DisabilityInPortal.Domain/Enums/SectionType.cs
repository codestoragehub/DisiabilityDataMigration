using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum SectionType
{
    [Display(Name = "Begin Application")]
    BeginApplication = 1,

    [Display(Name = "General Business Information")]
    GeneralBusinessInformation = 2,

    [Display(Name = "Legal Structure")]
    LegalStructure = 3,

    [Display(Name = "Franchise Information")]
    FranchiseInformation = 4,

    [Display(Name = "Headquarters Information")]
    HeadquartersInformation = 5,

    [Display(Name = "Mailing Address Information")]
    MailingAddressInformation = 6,

    [Display(Name = "Primary Owner Contact Information")]
    PrimaryOwnerContactInformation = 7,

    [Display(Name = "Company Contact Information")]
    CompanyContactInformation = 8,

    [Display(Name = "Trust Details")]
    TrustDetails = 9,

    [Display(Name = "Contractor Details")]
    ContractorDetails = 10,

    [Display(Name = "Transportation Details")]
    TransportationDetails = 11,

    [Display(Name = "Real Estate")]
    RealEstate = 12,

    [Display(Name = "Capabilities")]
    Capabilities = 13,

    [Display(Name = "Owners")]
    Owners = 14,

    [Display(Name = "Disability Impact")]
    DisabilityImpact = 15,

    [Display(Name = "Equipment And Vehicle")]
    EquipmentAndVehicle = 16,

    [Display(Name = "Management Contributions")]
    ManagementContributions = 17,

    [Display(Name = "Management Responsibilities")]
    ManagementResponsibilities = 18,

    [Display(Name = "Diversity Details")]
    DiversityDetails = 19,

    [Display(Name = "Contract Reference Details")]
    ContractReferenceDetails = 20,

    [Display(Name = "Bank And Credit Reference Details")]
    BankAndCreditReferenceDetails = 21,

    [Display(Name = "Management at Outside Firm")]
    ManagementAtOutsideFirm = 22,

    [Display(Name = "Additional Information")]
    AdditionalInformation = 23,

    [Display(Name = "Additional Document")]
    AdditionalDocument = 24,

    [Display(Name = "Business Relationship Details")]
    BusinessRelationshipDetails = 25,

    [Display(Name = "Financial/Size Information")]
    FinancialSizeInformation = 26,

    [Display(Name = "Management Change")]
    ManagementChange = 27
}