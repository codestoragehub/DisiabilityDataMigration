namespace DisabilityInPortal.ApplicationLayer.Features.AdditionalInformations.Dtos
{
    public class AdditionalInformationDto
    {
        public int AdditionalInformationId { get; set; }

        public bool IsInvolvedInLawsuit { get; set; }
        public bool IsInvolvedInBankruptcy { get; set; }
        public bool HasBeenDeniedCertification { get; set; }
        public bool RequiresAccommodationsDuringSiteVisit { get; set; }

        public int? LawsuitDocumentId { get; set; }
        public int? BankruptcyDocumentId { get; set; }
        public int? CertificationDenialDocumentId { get; set; }
        public int? SiteVisitAccomodationRequirementsDocumentId { get; set; }
        public int ApplicationId { get; set; }
        public string SiteVisitInfo { get; set; }
    }
}
