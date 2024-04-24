using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class TransportationDetailRepository : ITransportationDetailRepository
    {
        private readonly IRepositoryAsync<TransportationDetail> _repository;

        public TransportationDetailRepository(IRepositoryAsync<TransportationDetail> repository)
        {
            _repository = repository;
        }

        public async Task<TransportationDetail> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(r => r.ApplicationId == applicationId)
                .FirstOrDefaultAsync();
        }
    }
}