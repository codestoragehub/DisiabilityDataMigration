using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IRepositoryAsync<Income> _repository;

        public IncomeRepository(IRepositoryAsync<Income> repository)
        {
            _repository = repository;
        }

        public Task<Income> CreateIncomeAsync(Income income)
        {
            return _repository.AddAsync(income);
        }
        public Task<Income> GetIncomeByIdAsync(int incomeid)
        {
            return _repository.Entities
                .Include(f => f.FinancialSizeInfo)
                .Where(i => i.IncomeId == incomeid)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Income>> GetIncomeListAsyncByFinancialSizeId(int financialSizeInfoId)
        {
            return await _repository.Entities.Where(x => x.FinancialSizeInfoId == financialSizeInfoId)                
                .OrderByDescending(i => i.Year).ThenBy(i=>i.IncomeType)                
                .ToListAsync();
        }

        public Task<Income> GetByDocumentIdAsync(int documentId)
        {
            return _repository.Entities.FirstOrDefaultAsync(i => i.DocumentId == documentId);
        }

        public async Task UpdateIncomeAsync(Income income)
        {
            await _repository.UpdateAsync(income);
        }

        public async Task DeleteIncomeAsync(Income income)
        {
            await _repository.DeleteAsync(income);
        }
    }
}
