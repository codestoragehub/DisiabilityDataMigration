using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ITrustDetailRepository
    {
        Task<TrustDetail> GetByApplicationIdAsync(int applicationId);
    }
}