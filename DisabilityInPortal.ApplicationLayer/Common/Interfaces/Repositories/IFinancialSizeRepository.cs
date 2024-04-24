using DisabilityInPortal.Domain.Entities;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IFinancialSizeRepository
    {
        Task<FinancialSizeInfo> GetByApplicationIdAsync(int applicationId);
    }
}
