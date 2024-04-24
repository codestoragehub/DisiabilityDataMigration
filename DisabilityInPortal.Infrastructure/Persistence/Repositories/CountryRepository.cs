using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IRepositoryAsync<Country> _repository;

        public CountryRepository(IRepositoryAsync<Country> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(Country country)
        {
            await _repository.DeleteAsync(country);
        }

        public async Task<Country> GetByIdAsync(int countryId)
        {
            return await _repository.Entities.Where(p => p.CountryId == countryId).FirstOrDefaultAsync();
        }

        public async Task<List<Country>> GetListAsync()
        {
            return await _repository.Entities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<int> InsertAsync(Country country)
        {
            await _repository.AddAsync(country);
            return country.CountryId;
        }

        public async Task UpdateAsync(Country country)
        {
            await _repository.UpdateAsync(country);
        }
    }
}
