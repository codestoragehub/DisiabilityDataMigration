using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("Owners")]
public class Owner
{
    public int OwnerId { get; set; }

    [StringLength(150)]
    public string Name { get; set; }

    [StringLength(150)]
    public string Title { get; set; }

    public GenderType Gender { get; set; }

    [StringLength(128)]
    public string GenderOther { get; set; }

    public decimal Ownership { get; set; }
    public bool DisabilityStatus { get; set; }
    public bool ParticipatesShareVoting { get; set; }
    public bool DailyManagement { get; set; }
    public bool USCitizen { get; set; }
    public EthnicityType Ethinicity { get; set; }

    [StringLength(128)]
    public string EthinicityOther { get; set; }

    public bool IsLGBT { get; set; }
    public int? DocumentId { get; set; }
    public Document Document { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }
    public int? CountryId { get; set; }
    public Country Country { get; set; }
}