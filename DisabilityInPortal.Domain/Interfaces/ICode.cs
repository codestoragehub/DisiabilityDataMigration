using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Domain.Interfaces;

public interface ICode
{
    string Code { get; set; }
    string Description { get; set; }
    List<Capability> Capabilities { get; set; }
    List<SupplierProfileCapability> SupplierProfileCapabilities { get; set; }
}