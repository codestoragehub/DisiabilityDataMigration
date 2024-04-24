using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class DiversityRepository : IDiversityRepository
    {
        private readonly IRepositoryAsync<Diversity> _repository;

        public DiversityRepository(IRepositoryAsync<Diversity> repository)
        {
            _repository = repository;
        }

        public Task<Diversity> GetDiversityByIdAsync(int diversityId)
        {
            return _repository.Entities
                .Include(f => f.Document)
                .Where(f => f.DiversityId == diversityId)
                .FirstOrDefaultAsync();
        }

        public Task<Diversity> CreateDiversityAsync(Diversity diversity)
        {
            return _repository.AddAsync(diversity);
        }

        public async Task UpdateDiversityAsync(Diversity diversity)
        {
            await _repository.UpdateAsync(diversity);
        }

        public async Task DeleteDiversityAsync(Diversity diversity)
        {
            await _repository.DeleteAsync(diversity);
        }

        public Task<List<Diversity>> GetListAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<List<Diversity>> GetListByApplicationIdAsync(int applicationId)
        {
            return _repository.Entities
                .Include(f => f.Document)
                .Where(f => f.ApplicationId == applicationId).ToListAsync();
        }

        public Task<Diversity> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
        }
    }
}