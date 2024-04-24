using DisabilityInPortal.ApplicationLayer.Features.Affidavits;

namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class PaymentDetailDto
{
    public bool IsRecertification { get; set; }
    public string ApplicationReference { get; set; }
    public int ApplicationId { get; set; }
    public string StripeCustomerId { get; set; }
    public string StripePaymentMethod { get; set; }
    public bool IsExpeditedApplication { get; set; }
    public int NumberOfDaysToExpedite { get; set; }
    public AffidavitDto Affidavit { get; set; }
}