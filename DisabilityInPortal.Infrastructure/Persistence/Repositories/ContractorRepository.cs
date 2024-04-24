using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.Domain;
using Microsoft.EntityFrameworkCore;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class ContractorRepository: IContractorRepository
    {
        private readonly IRepositoryAsync<Contractor> _repository;
        public ContractorRepository(IRepositoryAsync<Contractor> repository)
        {
            _repository = repository;
        }

        public async Task<Contractor> GetByIdAsync(int companyId)
        {
            return await _repository.Entities.Where(p => p.CompanyId == companyId).FirstOrDefaultAsync();
        }
        public Task<Contractor> CreateContractorAsync(Contractor contractor)
        {
            return _repository.AddAsync(contractor);
        }

        public async Task UpdateContractorAsync(Contractor contractor)
        {
            await _repository.UpdateAsync(contractor);
        }
    }
}
