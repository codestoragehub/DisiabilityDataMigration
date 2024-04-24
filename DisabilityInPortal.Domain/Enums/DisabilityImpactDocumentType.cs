using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum DisabilityImpactDocumentType
{
    [Display(Name = "Disability Ratings Letter Document")]
    DisabilityRatingsLetterDocument = 2,

    [Display(Name = "Disability Statement Document")]
    DisabilityStatementDocument,

    [Display(Name = "IEP Document")]
    IEPDocument,

    [Display(Name = "Disability Benefits Document")]
    DisabilityBenefitsDocument,

    [Display(Name = "Disability Physician Form Document")]
    DisabilityPhysicianFormDocument
}