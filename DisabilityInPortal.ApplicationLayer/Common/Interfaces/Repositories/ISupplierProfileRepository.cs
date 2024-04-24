using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ISupplierProfileRepository
    {
        Task<SupplierProfile> GetFullSupplierProfileByUserIdAsync(string userId);
        Task<SupplierProfile> GetFullSupplierProfileByIdAsync(int supplierProfileId);
        Task<SupplierProfile> GetSupplierProfileByIdAllSubPropertiesAsync(int supplierProfileId);
        Task DeleteAsync(SupplierProfile supplierProfile);
        Task<SupplierProfile> GetByIdAsync(int supplierProfileId);
        Task<List<SupplierProfile>> GetListAsync();
        Task<SupplierProfile> InsertAsync(SupplierProfile supplierProfile);
        Task UpdateAsync(SupplierProfile supplierProfile);
        Task<bool> ExistsByUserIdAsync(string userId);
    }
}