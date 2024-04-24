using System;

namespace DisabilityInPortal.ApplicationLayer.Features.Affidavits;

public class AffidavitDto
{
    public int AffidavitId { get; set; }

    public bool IsAccepted { get; set; }
    public DateTime? AcceptedDate { get; set; }

    public string OS { get; set; }
    public string Browser { get; set; }
    public string IP { get; set; }

    public int ApplicationId { get; set; }
}