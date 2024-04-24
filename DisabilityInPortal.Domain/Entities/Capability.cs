using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Entities;

[Table("Capabilities")]
public class Capability : AuditBaseEntity
{
    public Capability()
    {
        NaicsCodes = new List<NaicsCode>();
        SicCodes = new List<SicCode>();
        UkSicCodes = new List<UkSicCode>();
        UnspscCodes = new List<UnspscCode>();
        UnNumberCodes = new List<UnNumberCode>();
    }

    public int CapabilityId { get; set; }

    [StringLength(1024)]
    public string ProductServiceDescription { get; set; }

    public GeographicalServiceAreaType GeographicalServiceArea { get; set; }

    public List<NaicsCode> NaicsCodes { get; set; }
    public List<SicCode> SicCodes { get; set; }
    public List<UkSicCode> UkSicCodes { get; set; }
    public List<UnspscCode> UnspscCodes { get; set; }
    public List<UnNumberCode> UnNumberCodes { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}