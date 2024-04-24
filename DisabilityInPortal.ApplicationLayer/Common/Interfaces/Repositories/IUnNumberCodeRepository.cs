using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IUnNumberCodeRepository
{
    Task<List<UnNumberCode>> SearchAsync(string searchTerm);
    Task<List<UnNumberCode>> GetListAsync(IEnumerable<string> unNumberCodes);
}