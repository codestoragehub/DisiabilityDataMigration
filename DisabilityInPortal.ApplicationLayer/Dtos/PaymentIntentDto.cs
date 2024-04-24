using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class PaymentIntentDto : AuditBaseEntityDto
{
    public int PaymentIntentId { get; set; }
    public string StripePaymentIntentId { get; set; }
    public string StripePaymentMethod { get; set; }
    public PaymentIntentStatus PaymentIntentStatus { get; set; }
    public int InvoiceId { get; set; }
}