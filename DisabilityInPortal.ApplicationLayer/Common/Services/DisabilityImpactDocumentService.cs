using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Services
{
    public class DisabilityImpactDocumentService : IDisabilityImpactDocumentService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationService _applicationService;

        private readonly IList<int> _skipFileUploadCertificationAgencies = new List<int> { 1, 2, 4, 6 };
        private readonly IList<int> _nonUSSkipFileUploadCertificationAgencies = new List<int> { 3, 7 };
        public DisabilityImpactDocumentService(
        IApplicationRepository applicationRepository,
        IApplicationService applicationService)
        {
            _applicationRepository = applicationRepository;
            _applicationService = applicationService;
        }

        public async Task<bool> SkipDocumentUploadAsync(int applicationId)
        {
            if (applicationId == 0)
                return false;

            var isStartUp = await _applicationService.IsStartupAsync(applicationId);
            var isNonUSACompany = !(await _applicationService.IsUsaBasedCompanyAsync(applicationId));
            var isVeteran = await _applicationService.IsVeteranAsync(applicationId);

            if (isVeteran||isStartUp)
                return false;

            var application = await _applicationRepository.GetFullApplicationByIdAsync(applicationId);

            if (isNonUSACompany)
                return application.ApplicationCertificationAgencies.Any(a =>
                _nonUSSkipFileUploadCertificationAgencies.Any(s => a.CertificationAgencyId == s));

            return application.ApplicationCertificationAgencies.Any(a =>
                _skipFileUploadCertificationAgencies.Any(s => a.CertificationAgencyId == s));
        }
    }
}
