using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly IRepositoryAsync<State> _repository;

        public StateRepository(IRepositoryAsync<State> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(State state)
        {
            await _repository.DeleteAsync(state);
        }

        public async Task<State> GetByIdAsync(int stateId)
        {
            return await _repository.Entities.Where(p => p.StateId == stateId).FirstOrDefaultAsync();
        }

        public async Task<List<State>> GetListAsync()
        {
            return await _repository.Entities.OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<int> InsertAsync(State state)
        {
            await _repository.AddAsync(state);
            return state.StateId;
        }

        public async Task UpdateAsync(State state)
        {
            await _repository.UpdateAsync(state);
        }

        public async Task<List<State>> GetListByCountryIdAsync(int countryId)
        {
            return await _repository.Entities.Where(p => p.CountryId == countryId).
                OrderBy(s => s.Name).ToListAsync();
        }
    }
}
