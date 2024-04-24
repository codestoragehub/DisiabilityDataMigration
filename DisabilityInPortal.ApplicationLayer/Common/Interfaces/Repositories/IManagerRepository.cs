using DisabilityInPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetManagersAsync(int operationAndControlId);
        Task<Manager> GetManagerByIdAsync(int managerId);
        Task<Manager> CreateManagerAsync(Manager manager);
        Task UpdateManagerAsync(Manager manager);
        Task DeleteManagerAsync(Manager manager);
        Task<bool> IsManagerExistsAsync(int operationAndControlId, int ownerId);
    }
}
