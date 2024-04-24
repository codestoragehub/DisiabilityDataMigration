using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface ISupplierProfileContractReferenceRepository
{
    Task<SupplierProfileContractReference> GetSupplierProfileContractReferenceByIdAsync(int supplierProfileContractReferencesId);
    Task<List<SupplierProfileContractReference>> GetSupplierProfileContractReferenceBySupplierProfileIdAsync(int supplierProfileId);
    Task<SupplierProfileContractReference> CreateSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference);
    Task UpdateSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference);
    Task DeleteSupplierProfileContractReferenceAsync(SupplierProfileContractReference supplierProfileContractReference);
    Task<List<SupplierProfileContractReference>> GetListAsync();
}