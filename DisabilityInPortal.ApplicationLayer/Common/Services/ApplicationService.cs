using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<string> CreateUniqueApplicationReferenceAsync()
    {
        string applicationReference;
        do
        {
            applicationReference = Application.GenerateApplicationReference();
        } while (await _applicationRepository.ExistsByReferenceAsync(applicationReference));

        return applicationReference;
    }

    public async Task<bool> IsUsaBasedCompanyAsync(int applicationId)
    {
        return await _applicationRepository.IsUsaBasedCompanyAsync(applicationId);
    }

    public async Task<bool> IsVeteranAsync(int applicationId)
    {
        var applicationUser = await _applicationRepository.GetApplicationUserAsync(applicationId);

        var vetTypes = new List<VeteranStatusType>
        {
            VeteranStatusType.Veteran, VeteranStatusType.SDV, VeteranStatusType.SDVVAVerified
        };

        return vetTypes.Contains(applicationUser.VeteranStatusType);
    }

    public async Task<bool> IsStartupAsync(int applicationId)
    {
        var applicationUser = await _applicationRepository.GetApplicationUserAsync(applicationId);

        return applicationUser.IsStartUpCompany;
    }

    public async Task<ApplicationUser> GetApplicationUserAsync(int applicationId)
    {
        return await _applicationRepository.GetApplicationUserAsync(applicationId);
    }
}