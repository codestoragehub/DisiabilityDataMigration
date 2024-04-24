using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class AdditionalDocumentService : IAdditionalDocumentService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IApplicationService _applicationService;

    private readonly IList<int> _skipFileUploadCertificationAgencies = new List<int> { 1, 2, 4, 6 };

    public AdditionalDocumentService(
        IApplicationRepository applicationRepository,
        IApplicationService applicationService)
    {
        _applicationRepository = applicationRepository;
        _applicationService = applicationService;
    }

    public async Task<bool> IsDefenceFormDocumentRequiredAsync(int applicationId)
    {
        if (applicationId == 0)
            return false;

        var application = await _applicationRepository.GetFullApplicationByIdAsync(applicationId);
        if (application.ApplicationCertificationAgencies.Any(HasToSkip))
            return false;

        return await _applicationService.IsVeteranAsync(applicationId);
    }

    public async Task<bool> IsBusinessPlanDocumentRequiredAsync(int applicationId)
    {
        if (applicationId == 0)
            return false;

        var application = await _applicationRepository.GetFullApplicationByIdAsync(applicationId);

        return !application.ApplicationCertificationAgencies.Any(HasToSkip);
    }

    private bool HasToSkip(ApplicationCertificationAgency applicationCertAgency)
    {
        return _skipFileUploadCertificationAgencies.Any(ca => applicationCertAgency.CertificationAgencyId == ca);
    }
}