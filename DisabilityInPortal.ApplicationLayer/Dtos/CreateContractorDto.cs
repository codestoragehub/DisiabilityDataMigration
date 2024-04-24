namespace DisabilityInPortal.ApplicationLayer.Features.Contractors.Dtos
{
    public class CreateContractorDto
    {        
        public string LicenseNumber { get; set; }
        public string TradeSpecialty { get; set; }
        public int? DocumentId { get; set; }
        public int? CompanyId { get; set; }
    }
}
