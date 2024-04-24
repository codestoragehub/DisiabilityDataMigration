using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories
{
    public class WorkflowHistoryEventRepository : IWorkflowHistoryEventRepository
    {
        private readonly IRepositoryAsync<WorkflowHistoryEvent> _repository;

        public WorkflowHistoryEventRepository(IRepositoryAsync<WorkflowHistoryEvent> repository)
        {
            _repository = repository;
        }

        public async Task<List<WorkflowHistoryEvent>> GetByApplicationIdAsync(int applicationId)
        {
            return await _repository.Entities
                .Where(r => r.ApplicationId == applicationId)
                .Include(r => r.ApplicationUser)
                .ToListAsync();
        }

        public async Task CreateAsync(WorkflowHistoryEvent entity)
        {
            await _repository.AddAsync(entity);
        }
    }
}