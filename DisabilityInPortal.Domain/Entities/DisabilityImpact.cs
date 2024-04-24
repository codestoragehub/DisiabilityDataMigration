using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("DisabilityImpacts")]
public class DisabilityImpact
{
    public DisabilityImpact()
    {
        DisabilityImpactDocuments = new List<DisabilityImpactDocument>();
    }
    public int DisabilityImpactId { get; set; }

    [StringLength(1500)]
    [DataType(DataType.Text)]
    public string ApplicantInformation { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public List<DisabilityImpactDocument> DisabilityImpactDocuments { get; set; }
}