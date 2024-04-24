using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class TrustDetailRepository : ITrustDetailRepository
    {
        private readonly IRepositoryAsync<TrustDetail> _repository;

        public TrustDetailRepository(IRepositoryAsync<TrustDetail> repository)
        {
            _repository = repository;
        }

        public async Task<TrustDetail> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(r => r.ApplicationId == applicationId)
                .FirstOrDefaultAsync();
        }
    }
}