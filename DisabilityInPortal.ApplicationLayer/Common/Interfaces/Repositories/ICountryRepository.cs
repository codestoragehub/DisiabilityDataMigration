using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetListAsync();
        Task<Country> GetByIdAsync(int countryId);
        Task<int> InsertAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(Country country);
    }
}