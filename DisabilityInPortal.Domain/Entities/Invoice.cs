using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Helpers;

namespace DisabilityInPortal.Domain.Entities;

[Table("Invoices")]
public class Invoice : AuditBaseEntity
{
    public Invoice()
    {
        CurrencyType = CurrencyType.Usd;
        InvoiceStatus = InvoiceStatus.Created;
        InvoiceReference = GenerateInvoiceReference();
    }

    public int InvoiceId { get; set; }

    [StringLength(14)]
    public string InvoiceReference { get; set; }

    public decimal TotalAmount { get; set; }
    public long TotalAmountZeroDecimal => (long)TotalAmount * 100;
    public CurrencyType CurrencyType { get; set; }
    public InvoiceStatus InvoiceStatus { get; private set; }

    [StringLength(128)]
    public string StripePaymentMethod { get; set; }

    [StringLength(128)]
    public string StripeCustomerId { get; set; }

    public List<InvoiceItem> InvoiceItems { get; set; }


    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public Payment Payment { get; set; }
    public List<PaymentIntent> PaymentIntents { get; set; }


    public void MarkCancelled()
    {
        InvoiceStatus = InvoiceStatus.Cancelled;
    }

    public void MarkPaid()
    {
        InvoiceStatus = InvoiceStatus.Paid;
    }

    public static string GenerateInvoiceReference()
    {
        return ReferenceHelper.CreateReference(
            Constants.Constants.InvoiceReferencePrefix,
            Constants.Constants.ReferenceLength);
    }
}