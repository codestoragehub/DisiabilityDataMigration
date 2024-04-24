using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementContributionRepository : IManagementContributionRepository
{
    private readonly IRepositoryAsync<ManagementContribution> _repository;

    public ManagementContributionRepository(IRepositoryAsync<ManagementContribution> repository)
    {
        _repository = repository;
    }

    public Task<List<ManagementContribution>> GetManagementContributionsAsync(int applicationId)
    {
        return _repository.Entities
            .Where(f => f.ApplicationId == applicationId)
            .ToListAsync();
    }

    public Task<ManagementContribution> GetManagementContributionByIdAsync(int managementContributionId)
    {
        return _repository.Entities
            .Where(f => f.ManagementContributionId == managementContributionId)
            .FirstOrDefaultAsync();
    }

    public Task<ManagementContribution> CreateManagementContributionAsync(
        ManagementContribution managementContribution)
    {
        return _repository.AddAsync(managementContribution);
    }

    public async Task UpdateManagementContributionAsync(ManagementContribution managementContribution)
    {
        await _repository.UpdateAsync(managementContribution);
    }

    public async Task DeleteManagementContributionAsync(ManagementContribution managementContribution)
    {
        await _repository.DeleteAsync(managementContribution);
    }

    public Task<bool> ExistsByOwnerId(int ownerId)
    {
        return _repository.Entities.AnyAsync(r => r.OwnerId == ownerId);
    }
}