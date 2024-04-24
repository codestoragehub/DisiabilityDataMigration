namespace DisabilityInPortal.Domain.Payments;

public class StripeConfig
{
    public string PublishableKey { get; set; }
    public string SecretKey { get; set; }
    public string StripeWebhookSecret { get; set; }
}