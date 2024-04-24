using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories
{
    public interface IWorkflowHistoryEventRepository
    {
        Task CreateAsync(WorkflowHistoryEvent entity);
        Task<List<WorkflowHistoryEvent>> GetByApplicationIdAsync(int applicationId);
    }
}