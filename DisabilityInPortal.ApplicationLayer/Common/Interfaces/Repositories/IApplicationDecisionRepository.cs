using DisabilityInPortal.Domain.Entities;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IApplicationDecisionRepository
    {
        Task<ApplicationDecision> CreateAsync(ApplicationDecision applicationDecision);
        Task<ApplicationDecision> GetByApplicationIdAsync(int applicationId);
        Task UpdateAsync(ApplicationDecision applicationDecision);
    }
}