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
    public class SupplierProfileLegalStructureRepository : ISupplierProfileLegalStructureRepository
    {
        private readonly IRepositoryAsync<SupplierProfileLegalStructure> _repository;

        public SupplierProfileLegalStructureRepository(IRepositoryAsync<SupplierProfileLegalStructure> repository)
        {
            _repository = repository;
        }

        public Task<SupplierProfileLegalStructure> GetSupplierProfileLegalStructureByIdAsync(int supplierProfileLegalStructureId)
        {
            return _repository.Entities
                .Where(f => f.SupplierProfileLegalStructureId == supplierProfileLegalStructureId)
                .FirstOrDefaultAsync();
        }

        public Task<SupplierProfileLegalStructure> CreateSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure)
        {
            return _repository.AddAsync(supplierProfileLegalStructure);
        }

        public async Task UpdateSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure)
        {
            await _repository.UpdateAsync(supplierProfileLegalStructure);
        }

        public async Task DeleteSupplierProfileLegalStructureAsync(SupplierProfileLegalStructure supplierProfileLegalStructure)
        {
            await _repository.DeleteAsync(supplierProfileLegalStructure);
        }

        public Task<List<SupplierProfileLegalStructure>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<SupplierProfileLegalStructure>> GetListBySupplierProfileIdAsync(int supplierProfileId)
        {
            return _repository.Entities
                .Where(f => f.SupplierProfileId == supplierProfileId).ToListAsync(); ;
        }

    }
}
