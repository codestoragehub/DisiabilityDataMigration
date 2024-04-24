using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IIncomeRepository
    {
        Task<Income> GetIncomeByIdAsync(int incomeId);
        Task<List<Income>> GetIncomeListAsyncByFinancialSizeId(int financialSizeInfoId);
        Task<Income> GetByDocumentIdAsync(int documentId);
        Task<Income> CreateIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(Income income);
    }
}
