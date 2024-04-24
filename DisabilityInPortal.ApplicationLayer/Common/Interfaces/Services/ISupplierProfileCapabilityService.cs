using DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Commands.UpdateSupplierProfile;
using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services
{
    public interface ISupplierProfileCapabilityService
    {
        Task UpdateCapabilityAsync(SupplierProfile supplierProfile, UpdateSupplierProfileDto applicationDto);
        Task UpdateNaicsCodesAsync(SupplierProfile supplierProfile, IList<string> naicsCodes);
        Task UpdateSicCodesAsync(SupplierProfile supplierProfile, IList<string> sicCodes);
        Task UpdateUkSicCodesAsync(SupplierProfile supplierProfile, IList<string> ukSicCodes);
        Task UpdateUnspscCodesAsync(SupplierProfile supplierProfile, IList<string> unspscCodes);
        Task UpdateUnNumberCodesAsync(SupplierProfile supplierProfile, IList<string> unNumberCodes);
    }
}
