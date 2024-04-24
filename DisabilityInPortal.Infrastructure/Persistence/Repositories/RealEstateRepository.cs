using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly IRepositoryAsync<RealEstate> _repository;

        public RealEstateRepository(IRepositoryAsync<RealEstate> repository)
        {
            _repository = repository;
        }

        public async Task<RealEstate> GetRealEstateByIdAsync(int realEstateId)
        {
            return await _repository.Entities
                .Include(r => r.Facilities).ThenInclude(f => f.Address)
                .Where(r => r.RealEstateId == realEstateId)
                .FirstOrDefaultAsync();
        }
    }
}