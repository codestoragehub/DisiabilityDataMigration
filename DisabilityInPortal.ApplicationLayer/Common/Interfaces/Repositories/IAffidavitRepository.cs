using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IAffidavitRepository
    {
        Task<Affidavit> GetByApplicationIdAsync(int applicationId);
        Task<Affidavit> GetByIdAsync(int affidavitId);
        Task UpdateAsync(Affidavit entity);
    }
}