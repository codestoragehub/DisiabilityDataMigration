using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Helpers;

namespace DisabilityInPortal.Domain.Entities;

[Table("Payments")]
public class Payment : AuditBaseEntity
{
    public Payment()
    {
        PaymentReference = GeneratePaymentReference();
    }

    public int PaymentId { get; set; }

    [StringLength(14)]
    public string PaymentReference { get; set; }

    public decimal PaymentAmount { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public int PaymentIntentId { get; set; }
    public PaymentIntent PaymentIntent { get; set; }

    public static string GeneratePaymentReference()
    {
        return ReferenceHelper.CreateReference(
            Constants.Constants.PaymentReferencePrefix,
            Constants.Constants.ReferenceLength);
    }
}