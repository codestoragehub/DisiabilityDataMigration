using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetListAsync();

        Task<Company> GetByIdAsync(int companyId);
        Task<Company> GetCompanyByUserIdAsync(string userId);

        Task<int> InsertAsync(Company company);

        Task UpdateAsync(Company company);

        Task DeleteAsync(Company company);
    }
}
