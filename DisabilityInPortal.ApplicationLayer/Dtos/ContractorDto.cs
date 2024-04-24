namespace DisabilityInPortal.ApplicationLayer.Features.Contractors.Queries
{
    public class ContractorDto
    {
        public int ContractorId { get; set; }
        public string LicenseNumber { get; set; }
        public string TradeSpecialty { get; set; }
        public int? DocumentId { get; set; }        
        public int? CompanyId { get; set; }        
    }
}
