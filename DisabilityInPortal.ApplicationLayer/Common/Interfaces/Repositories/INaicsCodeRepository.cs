using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface INaicsCodeRepository
    {
        Task<List<NaicsCode>> GetListAsync(IEnumerable<string> naicsCodes);
        Task<List<NaicsCode>> SearchAsync(string searchTerm);
    }
}