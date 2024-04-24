using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class FinancialSizeRepository : IFinancialSizeRepository
    {
        private readonly IRepositoryAsync<FinancialSizeInfo> _repository;

        public FinancialSizeRepository(IRepositoryAsync<FinancialSizeInfo> repository)
        {
            _repository = repository;
        }

        public async Task<FinancialSizeInfo> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(f => f.ApplicationId == applicationId)
                .FirstOrDefaultAsync();
        }
    }
}
