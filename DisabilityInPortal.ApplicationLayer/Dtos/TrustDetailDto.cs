namespace DisabilityInPortal.ApplicationLayer.Features.TrustDetails.Dtos
{
    public class TrustDetailDto
    {
        public int TrustDetailId { get; set; }

        public bool IsBusinessControlledByTrust { get; set; }
        public bool? IsIrrevocable { get; set; }
        public bool IsBenefactor { get; set; }
        public bool IsGrantor { get; set; }
        public bool IsTrustee { get; set; }

        public int ApplicationId { get; set; }
        public int? DocumentId { get; set; }
    }
}