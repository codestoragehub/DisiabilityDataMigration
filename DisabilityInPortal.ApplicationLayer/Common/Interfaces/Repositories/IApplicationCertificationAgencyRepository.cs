using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IApplicationCertificationAgencyRepository
    {
        void RemoveRange(IEnumerable<ApplicationCertificationAgency> applicationCertificationAgencies);
        Task<ApplicationCertificationAgency> GetByDocumentIdAsync(int documentId);
    }
}