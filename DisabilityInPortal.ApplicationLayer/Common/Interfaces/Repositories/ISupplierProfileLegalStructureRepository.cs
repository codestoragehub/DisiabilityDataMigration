using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ISupplierProfileLegalStructureRepository
    {
        Task<SupplierProfileLegalStructure> GetSupplierProfileLegalStructureByIdAsync(int supplierProfileLegalStructureId);       
        Task<SupplierProfileLegalStructure> CreateSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure);
        Task UpdateSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure);
        Task DeleteSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure);
        Task<List<SupplierProfileLegalStructure>> GetListAsync();
        Task<List<SupplierProfileLegalStructure>> GetListBySupplierProfileIdAsync(int supplierProfileId);
    }
}
