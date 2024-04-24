using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IAdditionalInformationRepository
    {
        Task<AdditionalInformation> GetByApplicationIdAsync(int applicationId);
    }
}