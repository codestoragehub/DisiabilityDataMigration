namespace DisabilityInPortal.Domain.Payments.PaymentIntent;

public class CreatePaymentIntentRequest
{
    public long? Amount { get; set; }
    public string Currency { get; set; }
    public string PaymentMethod { get; set; }
    public string Customer { get; set; }
}