using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("PaymentDetails")]
public class PaymentDetail
{
    public int PaymentDetailId { get; set; }
    public bool IsRecertification { get; set; }

    [StringLength(128)]
    public string StripeCustomerId { get; set; }

    [StringLength(128)]
    public string StripePaymentMethod { get; set; }

    public bool IsExpeditedApplication { get; set; }
    public int NumberOfDaysToExpedite { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}