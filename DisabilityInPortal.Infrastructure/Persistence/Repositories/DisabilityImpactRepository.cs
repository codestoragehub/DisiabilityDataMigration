using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class DisabilityImpactRepository : IDisabilityImpactRepository
    {
        private readonly IRepositoryAsync<DisabilityImpact> _repository;

        public DisabilityImpactRepository(IRepositoryAsync<DisabilityImpact> repository)
        {
            _repository = repository;
        }

        public Task<DisabilityImpact> CreateDisabilityImpactAsync(DisabilityImpact disabiltyImpact)
        {
            return _repository.AddAsync(disabiltyImpact);
        }

        public Task<DisabilityImpact> GetDisabilityImpactByIdAsync(int disabilityImpactId)
        {
            return _repository.Entities
                .Where(d => d.DisabilityImpactId == disabilityImpactId)
                .FirstOrDefaultAsync();
        }

        public async Task<DisabilityImpact> GetDisabilityImpactByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .FirstOrDefaultAsync(r => r.ApplicationId == applicationId);
        }
        public async Task DeleteDisabilityImpactAsync(DisabilityImpact disabiltyImpact)
        {
            await _repository.DeleteAsync(disabiltyImpact);
        }
    }
}
