using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ISupplierProfileDocumentRepository
    {
        Task DeleteAsync(SupplierProfileDocument application);
        Task<SupplierProfileDocument> GetByIdAsync(int documentId);
        Task<List<SupplierProfileDocument>> GetListAsync();
        Task<SupplierProfileDocument> InsertAsync(SupplierProfileDocument application);
        Task UpdateAsync(SupplierProfileDocument application);
    }
}