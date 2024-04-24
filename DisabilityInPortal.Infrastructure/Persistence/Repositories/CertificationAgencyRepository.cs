using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class CertificationAgencyRepository : ICertificationAgencyRepository
    {
        private readonly IRepositoryAsync<CertificationAgency> _repository;

        public CertificationAgencyRepository(IRepositoryAsync<CertificationAgency> repository)
        {
            _repository = repository;
        }

        public async Task<List<CertificationAgency>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}