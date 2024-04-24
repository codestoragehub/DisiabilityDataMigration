namespace DisabilityInPortal.ApplicationLayer.Features.TransportationDetails.Dtos
{
    public class TransportationDetailDto
    {
        public int TransportationDetailId { get; set; }

        public bool DoesCompanyInvolveTransportation { get; set; }
        public string OperatingStatus { get; set; }
        public string CommonCarrier { get; set; }
        public string IndependentCarrier { get; set; }
        public string InsuranceCarrier { get; set; }
        public string Commodities { get; set; }
        public bool IsFleetContracted { get; set; }
        public bool IsFleetLeased { get; set; }
        public bool IsFleetOwned { get; set; }

        public int? ContractDocumentId { get; set; }
        public int? LeaseDocumentId { get; set; }

        public int ApplicationId { get; set; }
    }
}