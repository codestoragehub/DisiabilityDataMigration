using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IDisabilityImpactRepository
    {        
        Task<DisabilityImpact> CreateDisabilityImpactAsync(DisabilityImpact disabiltyImpact);        
        Task<DisabilityImpact> GetDisabilityImpactByIdAsync(int disabiltyImpactId);
        Task<DisabilityImpact> GetDisabilityImpactByApplicationIdAsync(int applicationId);
        Task DeleteDisabilityImpactAsync(DisabilityImpact disabiltyImpact);
    }
}
