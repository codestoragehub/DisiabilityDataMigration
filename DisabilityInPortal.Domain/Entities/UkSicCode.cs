using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Interfaces;

namespace DisabilityInPortal.Domain.Entities;

[Table("UkSicCodes")]
public class UkSicCode : ICode
{
    [StringLength(32)]
    public string Section { get; set; }

    [StringLength(256)]
    public string SectionDescription { get; set; }

    [StringLength(32)]
    public string Code { get; set; }

    [StringLength(256)]
    public string Description { get; set; }

    public List<Capability> Capabilities { get; set; }
    public List<SupplierProfileCapability> SupplierProfileCapabilities { get; set; }
}