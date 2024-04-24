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
    public class LegalStructureRepository : ILegalStructureRepository
    {
        private readonly IRepositoryAsync<LegalStructure> _repository;

        public LegalStructureRepository(IRepositoryAsync<LegalStructure> repository)
        {
            _repository = repository;
        }

        public Task<LegalStructure> GetLegalStructureByIdAsync(int legalStructureId)
        {
            return _repository.Entities
                .Include(x => x.LegalStructureDocuments)
                .Where(f => f.LegalStructureId == legalStructureId)
                .FirstOrDefaultAsync();
        }

        public Task<LegalStructure> CreateLegalStructureAsync(LegalStructure legalStructure)
        {
            return _repository.AddAsync(legalStructure);
        }

        public async Task UpdateLegalStructureAsync(LegalStructure legalStructure)
        {
            await _repository.UpdateAsync(legalStructure);
        }

        public async Task DeleteLegalStructureAsync(LegalStructure legalStructure)
        {
            await _repository.DeleteAsync(legalStructure);
        }

        public Task<List<LegalStructure>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<LegalStructure>> GetListByCompanyIdAsync(int companyId)
        {
            return _repository.Entities
                 .Include(x=>x.LegalStructureDocuments)
                 .Where(f => f.CompanyId == companyId).ToListAsync();
        }

        public Task<List<LegalStructure>> GetListByApplicationIdAsync(int applicationId)
        {
            return _repository.Entities
                .Include(x => x.LegalStructureDocuments)
                .Where(f => f.ApplicationId == applicationId).ToListAsync(); ;
        }
    }
}
