namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class InvoiceItemDto
{
    public int InvoiceItemId { get; set; }
    public int Quantity { get; set; }
    public string ItemName { get; set; }
    public decimal UnitAmount { get; set; }
    public decimal TotalAmount { get; set; }
}