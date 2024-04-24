namespace DisabilityInPortal.Domain.Payments;

public class PaymentsConfiguration
{
    public StripeConfig StripeConfig { get; set; }
    public decimal ApplicationCertificationFee { get; set; }
    public decimal ApplicationReCertificationFee { get; set; }
    public decimal ExpediteApplicationFeeFor30Days { get; set; }
    public decimal ExpediteApplicationFeeFor60Days { get; set; }
}