using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("Affidavits")]
public class Affidavit
{
    public int AffidavitId { get; set; }

    public bool IsAccepted { get; set; }
    public DateTime? AcceptedDate { get; set; }

    [StringLength(250)]
    public string OS { get; set; }

    [StringLength(250)]
    public string Browser { get; set; }

    [StringLength(250)]
    public string IP { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}