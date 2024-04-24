using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IUnspscCodeRepository
    {
        Task<List<UnspscCode>> SearchAsync(string searchTerm);
        Task<List<UnspscCode>> GetListAsync(IEnumerable<string> unspscCodes);
    }
}