using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById
{
    public class CertificationAgencyDto
    {
        public int CertificationAgencyId { get; set; }
        public string Name { get; set; }
        public bool? IsDocumentRequired { get; set; }
        public DocumentType? DocumentType { get; set; }
    }
}