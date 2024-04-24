using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Models;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;

public interface IApplicationAssigneeRepository
{
    Task<List<ApplicationAssignee>> GetApplicationAssigneesAsync(int applicationId);
    Task DeleteAsync(ApplicationAssignee applicationAssignee);
    Task<int> InsertAsync(ApplicationAssignee applicationAssignee);
    Task<List<AssignedCountForUser>> GetAssignedCountsForAllUsersAsync();
}