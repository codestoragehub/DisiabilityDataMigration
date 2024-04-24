using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IApplicationCloningService
{
    Task<Application> CloneFromExistingApplicationAsync(int applicationId);
}