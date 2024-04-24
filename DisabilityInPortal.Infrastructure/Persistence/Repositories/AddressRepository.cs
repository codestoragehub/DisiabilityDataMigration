using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IRepositoryAsync<Address> _repository;

        public AddressRepository(IRepositoryAsync<Address> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(Address address)
        {
            await _repository.DeleteAsync(address);
        }

        public async Task<Address> GetByIdAsync(int addressId)
        {
            return await _repository.Entities.Where(p => p.AddressId == addressId).FirstOrDefaultAsync();
        }

        public async Task<List<Address>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Address address)
        {
            await _repository.AddAsync(address);
            return address.AddressId;
        }

        public async Task UpdateAsync(Address address)
        {
            await _repository.UpdateAsync(address);
        }
        public async Task<List<Address>> GetListByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities.Where(p => p.ApplicationId == applicationId).ToListAsync();
        }
    }
}
