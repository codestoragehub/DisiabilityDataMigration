using System.Collections.Generic;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class InvoiceDto
{
    public int InvoiceId { get; set; }
    public string InvoiceReference { get; set; }
    public decimal TotalAmount { get; set; }
    public long TotalAmountZeroDecimal => (long)TotalAmount * 100;
    public CurrencyType CurrencyType { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public string StripePaymentMethod { get; set; }
    public string StripeCustomerId { get; set; }
    public List<InvoiceItemDto> InvoiceItems { get; set; }
    public PaymentDto Payment { get; set; }
    public List<PaymentIntentDto> PaymentIntents { get; set; }
}