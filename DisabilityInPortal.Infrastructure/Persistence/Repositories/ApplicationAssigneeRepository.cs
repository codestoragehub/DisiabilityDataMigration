using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ApplicationAssigneeRepository : IApplicationAssigneeRepository
{
    private readonly IRepositoryAsync<ApplicationAssignee> _repository;

    public ApplicationAssigneeRepository(IRepositoryAsync<ApplicationAssignee> repository)
    {
        _repository = repository;
    }

    public Task<List<ApplicationAssignee>> GetApplicationAssigneesAsync(int applicationId)
    {
        return _repository.Entities
            .Include(a => a.User)
            .Where(a => a.ApplicationId == applicationId)
            .ToListAsync();
    }

    public async Task DeleteAsync(ApplicationAssignee applicationAssignee)
    {
        await _repository.DeleteAsync(applicationAssignee);
    }

    public async Task<int> InsertAsync(ApplicationAssignee applicationAssignee)
    {
        await _repository.AddAsync(applicationAssignee);

        return applicationAssignee.ApplicationAssigneeId;
    }

    public Task<List<AssignedCountForUser>> GetAssignedCountsForAllUsersAsync()
    {
        return _repository.Entities
            .Where(a => a.User.UserRoles.Any(ur => Constants.AssignmentRoles.Contains(ur.Role.Name)))
            .GroupBy(a => a.UserId)
            .Select(g => new AssignedCountForUser { UserId = g.Key, Count = g.Count() })
            .ToListAsync();
    }
}