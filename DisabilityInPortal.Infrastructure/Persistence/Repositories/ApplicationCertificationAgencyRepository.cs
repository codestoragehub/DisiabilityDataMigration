using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class ApplicationCertificationAgencyRepository : IApplicationCertificationAgencyRepository
    {
        private readonly IRepositoryAsync<ApplicationCertificationAgency> _repository;

        public ApplicationCertificationAgencyRepository(IRepositoryAsync<ApplicationCertificationAgency> repository)
        {
            _repository = repository;
        }

        public void RemoveRange(IEnumerable<ApplicationCertificationAgency> applicationCertificationAgencies)
        {
            _repository.RemoveRange(applicationCertificationAgencies);
        }

        public Task<ApplicationCertificationAgency> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(aca => aca.DocumentId == documentId);
        }
    }
}