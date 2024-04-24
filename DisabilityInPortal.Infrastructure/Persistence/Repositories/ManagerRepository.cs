using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly IRepositoryAsync<Manager> _repository;

        public ManagerRepository(IRepositoryAsync<Manager> repository)
        {
            _repository = repository;
        }

        public Task<List<Manager>> GetManagersAsync(int operationAndControlId)
        {
            return _repository.Entities
                .Where(o => o.OperationAndControlId == operationAndControlId)
                .Include(o => o.OperationAndControl)
                .Include(o => o.Owner)
                .ToListAsync();
        }

        public Task<Manager> GetManagerByIdAsync(int managerId)
        {
            return _repository.Entities
                .Where(m => m.ManagerId == managerId)
                .Include(m => m.OperationAndControl)
                .Include(m => m.Owner)
                .FirstOrDefaultAsync();
        }

        public Task<Manager> CreateManagerAsync(Manager manager)
        {
            return _repository.AddAsync(manager);
        }

        public async Task UpdateManagerAsync(Manager manager)
        {
            await _repository.UpdateAsync(manager);
        }

        public async Task DeleteManagerAsync(Manager manager)
        {
            await _repository.DeleteAsync(manager);
        }

        public Task<bool> IsManagerExistsAsync(int operationAndControlId, int ownerId)
        {
            return _repository.Entities.AnyAsync(m => m.OperationAndControlId == operationAndControlId && m.OwnerId == ownerId);
        }
    }
}
