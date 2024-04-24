using System.Threading.Tasks;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IApplicationService
{
    Task<string> CreateUniqueApplicationReferenceAsync();
    Task<bool> IsUsaBasedCompanyAsync(int applicationId);
    Task<bool> IsVeteranAsync(int applicationId);
    Task<bool> IsStartupAsync(int applicationId);
    Task<ApplicationUser> GetApplicationUserAsync(int applicationId);
}