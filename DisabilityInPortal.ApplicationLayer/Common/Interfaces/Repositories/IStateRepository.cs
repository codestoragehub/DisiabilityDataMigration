using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilityInPortal.Domain;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IStateRepository
    {
        Task<List<State>> GetListAsync();

        Task<State> GetByIdAsync(int stateId);

        Task<int> InsertAsync(State state);

        Task UpdateAsync(State state);

        Task DeleteAsync(State state);
        Task<List<State>> GetListByCountryIdAsync(int countryId);
    }
}
