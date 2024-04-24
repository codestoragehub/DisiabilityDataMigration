using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class PaymentDto : AuditBaseEntityDto
{
    public int PaymentId { get; set; }
    public string PaymentReference { get; set; }
    public decimal PaymentAmount { get; set; }
    
    public int InvoiceId { get; set; }
    public InvoiceDto Invoice { get; set; }
    
    public int PaymentIntentId { get; set; }
    public PaymentIntentDto PaymentIntent { get; set; }
}