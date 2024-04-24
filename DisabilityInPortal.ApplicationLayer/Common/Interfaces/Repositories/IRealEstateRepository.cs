using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IRealEstateRepository
    {
        Task<RealEstate> GetRealEstateByIdAsync(int realEstateId);
    }
}