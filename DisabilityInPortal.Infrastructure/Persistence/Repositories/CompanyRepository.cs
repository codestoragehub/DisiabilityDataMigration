using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.Domain;
using Microsoft.EntityFrameworkCore;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IRepositoryAsync<Company> _repository;

        public CompanyRepository(IRepositoryAsync<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> GetCompanyByUserIdAsync(string userId)
        {
            return await _repository.Entities
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task DeleteAsync(Company company)
        {
            await _repository.DeleteAsync(company);
        }

        public async Task<Company> GetByIdAsync(int companyId)
        {
            return await _repository.Entities
                .Include(a => a.Documents)
                .Where(p => p.CompanyId == companyId).FirstOrDefaultAsync();
        }

        public async Task<List<Company>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Company company)
        {
            await _repository.AddAsync(company);
            return company.CompanyId;
        }

        public async Task UpdateAsync(Company company)
        {
            await _repository.UpdateAsync(company);
        }
    }
}
