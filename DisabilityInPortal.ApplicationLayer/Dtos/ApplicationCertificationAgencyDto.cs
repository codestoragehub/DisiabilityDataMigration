namespace DisabilityInPortal.ApplicationLayer.Features.Applications.Queries.GetApplicationById
{
    public class ApplicationCertificationAgencyDto
    {
        public int ApplicationId { get; set; }
        public int CertificationAgencyId { get; set; }
        public int? DocumentId { get; set; }
        public bool Checked { get; set; }
        public CertificationAgencyDto CertificationAgencyDto { get; set; }
    }
}