using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IContractorRepository
    {
        Task<Contractor> GetByIdAsync(int companyId);
        Task<Contractor> CreateContractorAsync(Contractor Contractor);
        Task UpdateContractorAsync(Contractor Contractor);
        
    }
}
