using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class AffidavitRepository : IAffidavitRepository
    {
        private readonly IRepositoryAsync<Affidavit> _repository;

        public AffidavitRepository(IRepositoryAsync<Affidavit> repository)
        {
            _repository = repository;
        }

        public async Task<Affidavit> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(r => r.ApplicationId == applicationId)
                .FirstOrDefaultAsync();
        }

        public async Task<Affidavit> GetByIdAsync(int affidavitId)
        {
            return await _repository.Entities
                .Where(r => r.AffidavitId == affidavitId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Affidavit entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}