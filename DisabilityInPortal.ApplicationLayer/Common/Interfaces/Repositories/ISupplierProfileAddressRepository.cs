using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ISupplierProfileAddressRepository
    {
        Task<List<SupplierProfileAddress>> GetListAsync();

        Task<SupplierProfileAddress> GetByIdAsync(int addressId);

        Task<SupplierProfileAddress> InsertAsync(SupplierProfileAddress address);

        Task UpdateAsync(SupplierProfileAddress address);

        Task DeleteAsync(SupplierProfileAddress address);

        Task<List<SupplierProfileAddress>> GetListBySupplierProfileIdAsync(int SupplierProfileId ,int AddressTypeId);
    }
}
