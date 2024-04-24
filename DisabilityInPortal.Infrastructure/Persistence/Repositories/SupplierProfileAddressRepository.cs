using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class SupplierProfileAddressRepository : ISupplierProfileAddressRepository
    {
        private readonly IRepositoryAsync<SupplierProfileAddress> _repository;

        public SupplierProfileAddressRepository(IRepositoryAsync<SupplierProfileAddress> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(SupplierProfileAddress supplierProfileAddress)
        {
            await _repository.DeleteAsync(supplierProfileAddress);
        }

        public async Task<SupplierProfileAddress> GetByIdAsync(int addressId)
        {
            return await _repository.Entities.Where(p => p.AddressId == addressId).FirstOrDefaultAsync();
        }

        public async Task<List<SupplierProfileAddress>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<SupplierProfileAddress> InsertAsync(SupplierProfileAddress supplierProfileAddress)
        {
            return await _repository.AddAsync(supplierProfileAddress);
        }

        public async Task UpdateAsync(SupplierProfileAddress supplierProfileAddress)
        {
            await _repository.UpdateAsync(supplierProfileAddress);
        }
        public async Task<List<SupplierProfileAddress>> GetListBySupplierProfileIdAsync(int supplierProfileId,int addressTypeId)
        {
            return await _repository.Entities.Where(p => p.SupplierProfileId == supplierProfileId && p.AddressType ==(AddressType)addressTypeId).ToListAsync();
        }
    }
}
