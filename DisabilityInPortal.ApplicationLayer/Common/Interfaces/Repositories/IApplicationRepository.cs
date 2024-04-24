using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IApplicationRepository
{
    Task<List<Application>> GetListAsync();
    Task<Application> GetFullApplicationByIdAsync(int applicationId);
    Task<Application> GetApplicationByIdAllSubPropertiesAsync(int applicationId);

    Task<Application> GetByReferenceAsync(
        string applicationReference,
        params ApplicationPropertyType[] applicationPropertyTypes);

    Task<Application> GetByIdAsync(
        int applicationId,
        params ApplicationPropertyType[] applicationPropertyTypes);

    Task<bool> ExistsAsync(int applicationId);
    Task<bool> ExistsWithStatusAsync(int applicationId, ApplicationStatus status);
    Task<bool> ExistsByReferenceAsync(string applicationReference);
    Task<int> InsertAsync(Application application);
    Task UpdateAsync(Application application);
    Task DeleteAsync(Application application);
    Task<Application> GetApplicationByUserIdAndStatusAsync(string userId, ApplicationStatus applicationStatus);
    Task<List<Application>> GetApplicationsByUserIdAsync(string userId);
    Task<bool> IsUsaBasedCompanyAsync(int applicationId);
    Task<ApplicationUser> GetApplicationUserAsync(int applicationId);
    Task<List<Application>> GetAssignedApplications(string userId);
}