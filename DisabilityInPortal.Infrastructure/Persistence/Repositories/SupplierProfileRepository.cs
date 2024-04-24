using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class SupplierProfileRepository : ISupplierProfileRepository
    {
        private readonly IRepositoryAsync<SupplierProfile> _repository;

        public SupplierProfileRepository(IRepositoryAsync<SupplierProfile> repository)
        {
            _repository = repository;
        }

        private IQueryable<SupplierProfile> SupplierProfiles => _repository.Entities;

        public async Task DeleteAsync(SupplierProfile supplierProfile)
        {
            await _repository.DeleteAsync(supplierProfile);
        }

        public async Task<SupplierProfile> GetByIdAsync(int supplierProfileId)
        {
            return await _repository.GetByIdAsync(supplierProfileId);
        }
        public async Task<SupplierProfile> GetFullSupplierProfileByUserIdAsync(string userId)
        {
            return await _repository.Entities
                .Include(p => p.AddressList)
                .Include(p => p.CertificationAgencies)
                .Include(p => p.LegalStructureList)
                .Include(p => p.ContractReferenceList).ThenInclude(c=>c.Address)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.NaicsCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.SicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UkSicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnspscCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnNumberCodes)
            .Where(p => p.UserId == userId)
            .FirstOrDefaultAsync();
        }
        public async Task<SupplierProfile> GetFullSupplierProfileByIdAsync(int supplierProfileId)
        {
            return await _repository.Entities
                .Include(p => p.AddressList)
                .Include(p => p.CertificationAgencies)
                .Include(p => p.LegalStructureList)
                .Include(p => p.ContractReferenceList).ThenInclude(c => c.Address)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.NaicsCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.SicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UkSicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnspscCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnNumberCodes)
            .Where(p => p.SupplierProfileId == supplierProfileId)
            .FirstOrDefaultAsync();
        }
        public async Task<SupplierProfile> GetSupplierProfileByIdAllSubPropertiesAsync(int supplierProfileId)
        {
            return await _repository.Entities
                .Include(p => p.AddressList)
                .Include(p => p.CertificationAgencies)
                .Include(p => p.LegalStructureList)
                .Include(p => p.ContractReferenceList).ThenInclude(c => c.Address)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.NaicsCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.SicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UkSicCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnspscCodes)
                .Include(a => a.ProfileCapability).ThenInclude(c => c.UnNumberCodes)
            .Where(p => p.SupplierProfileId == supplierProfileId)
            .FirstOrDefaultAsync();
        }

        public async Task<List<SupplierProfile>> GetListAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<SupplierProfile> InsertAsync(SupplierProfile supplierProfile)
        {
            return _repository.AddAsync(supplierProfile);
        }

        public Task UpdateAsync(SupplierProfile supplierProfile)
        {
            return _repository.UpdateAsync(supplierProfile);
        }
        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await _repository.Entities.AnyAsync(p => p.UserId == userId);
        }
    }
}
