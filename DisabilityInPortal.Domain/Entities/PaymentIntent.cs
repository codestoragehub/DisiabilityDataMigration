using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("PaymentIntents")]
public class PaymentIntent : AuditBaseEntity
{
    public int PaymentIntentId { get; set; }

    [StringLength(128)]
    public string StripePaymentIntentId { get; set; }
    
    [StringLength(128)]
    public string StripePaymentMethod { get; set; }

    public PaymentIntentStatus PaymentIntentStatus { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}