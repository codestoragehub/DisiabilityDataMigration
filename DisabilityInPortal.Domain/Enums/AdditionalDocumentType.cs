using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum AdditionalDocumentType
{
    [Display(Name = "Other")]
    Other = 0,

    [Display(Name = "Business Plan")]
    BusinessPlan = 1,

    [Display(Name = "Applicable Operating License and/or Permit")]
    OperatingLicenseOrPermit = 2,

    [Display(Name = "Third Party Agreement")]
    ThirdPartyAgreement = 3,

    [Display(Name = "Current Union Agreement")]
    UnionAgreement = 4,

    [Display(Name = "Defense Form Document")]
    DefenceFormDocument = 5
}