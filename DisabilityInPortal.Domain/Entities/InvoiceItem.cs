using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("InvoiceItems")]
public class InvoiceItem : AuditBaseEntity
{
    public int InvoiceItemId { get; set; }
    public int Quantity { get; set; }

    [StringLength(1024)]
    public string ItemName { get; set; }

    public decimal UnitAmount { get; set; }
    public decimal TotalAmount { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}