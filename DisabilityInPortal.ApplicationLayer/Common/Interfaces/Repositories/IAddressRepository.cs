using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetListAsync();

        Task<Address> GetByIdAsync(int addressId);

        Task<int> InsertAsync(Address address);

        Task UpdateAsync(Address address);

        Task DeleteAsync(Address address);

        Task<List<Address>> GetListByApplicationIdAsync(int applicationId);
    }
}
