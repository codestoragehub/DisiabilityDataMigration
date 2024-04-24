using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUkSicCodeRepository
    {
        Task<List<UkSicCode>> SearchAsync(string searchTerm);
        Task<List<UkSicCode>> GetListAsync(IEnumerable<string> ukSicCodes);
    }
}