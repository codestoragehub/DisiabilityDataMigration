using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities
{
    [Table("AdditionalInformations")]
    public class AdditionalInformation
    {
        public int AdditionalInformationId { get; set; }
        public bool IsInvolvedInLawsuit { get; set; }
        public bool IsInvolvedInBankruptcy { get; set; }
        public bool HasBeenDeniedCertification { get; set; }
        public bool RequiresAccommodationsDuringSiteVisit { get; set; }
        public int? LawsuitDocumentId { get; set; }
        public Document LawsuitDocument { get; set; }
        public int? BankruptcyDocumentId { get; set; }
        public Document BankruptcyDocument { get; set; }
        public int? CertificationDenialDocumentId { get; set; }
        public Document CertificationDenialDocument { get; set; }
        public int? SiteVisitAccomodationRequirementsDocumentId { get; set; }
        public Document SiteVisitAccomodationRequirementsDocument { get; set; }       
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        [StringLength(500)]
        public string SiteVisitInfo { get; set; }
    }
}
