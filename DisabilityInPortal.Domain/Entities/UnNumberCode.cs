using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Interfaces;

namespace DisabilityInPortal.Domain.Entities;

[Table("UnNumberCodes")]
public class UnNumberCode : ICode
{
    [StringLength(32)]
    public string Code { get; set; }

    [StringLength(512)]
    public string Description { get; set; }

    public List<Capability> Capabilities { get; set; }
    public List<SupplierProfileCapability> SupplierProfileCapabilities { get; set; }
}