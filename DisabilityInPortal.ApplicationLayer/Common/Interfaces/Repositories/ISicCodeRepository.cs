using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface ISicCodeRepository
    {
        Task<List<SicCode>> SearchAsync(string searchTerm);
        Task<List<SicCode>> GetListAsync(IEnumerable<string> sicCodes);
    }
}