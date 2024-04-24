using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum AddressType
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Headquarters Information")]
    HeadquartersInformation = 1,

    [Display(Name = "Mailing Address")]
    MailingAddress = 2,

    [Display(Name = "Primary Owner Contact")]
    PrimaryOwnerContact = 3,

    [Display(Name = "Company Contact")]
    CompanyContact = 4,

    [Display(Name = "Facility")]
    Facility = 5,

    [Display(Name = "ContractReference")]
    ContractReference = 6,

    [Display(Name = "Bank and Credit Reference")]
    BankAndCreditReference = 7,

    [Display(Name = "Business RelationShip")]
    BusinessRelationShip = 8
}