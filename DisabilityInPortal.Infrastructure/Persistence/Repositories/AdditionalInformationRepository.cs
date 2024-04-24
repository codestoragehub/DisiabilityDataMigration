using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class AdditionalInformationRepository : IAdditionalInformationRepository
    {
        private readonly IRepositoryAsync<AdditionalInformation> _repository;

        public AdditionalInformationRepository(IRepositoryAsync<AdditionalInformation> repository)
        {
            _repository = repository;
        }

        public async Task<AdditionalInformation> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(r => r.ApplicationId == applicationId)
                .FirstOrDefaultAsync();
        }
    }
}