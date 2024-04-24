using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Services
{
    public class BusinessRelationshipService : IBusinessRelationshipService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationService _applicationService;

        private readonly IList<int> _skipFileUploadCertificationAgencies = new List<int> { 1, 2, 3, 4, 6 };
        public BusinessRelationshipService(
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

            var isVeteran = await _applicationService.IsVeteranAsync(applicationId);
            var isStartUp = await _applicationService.IsStartupAsync(applicationId);

            if (isVeteran || isStartUp)
                return false;

            var application = await _applicationRepository.GetFullApplicationByIdAsync(applicationId);

            return application.ApplicationCertificationAgencies.Any(a =>
                _skipFileUploadCertificationAgencies.Any(s => a.CertificationAgencyId == s));
        }
    }

}
