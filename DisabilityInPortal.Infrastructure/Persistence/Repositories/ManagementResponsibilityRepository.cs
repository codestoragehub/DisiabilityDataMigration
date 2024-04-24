using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementResponsibilityRepository : IManagementResponsibilityRepository
{
    private readonly IRepositoryAsync<ManagementResponsibility> _repository;

    public ManagementResponsibilityRepository(IRepositoryAsync<ManagementResponsibility> repository)
    {
        _repository = repository;
    }

    public async Task<ManagementResponsibility> GetManagementResponsibilityByIdAsync(int managementResponsibilityId)
    {
        return await _repository.Entities
            .Include(r => r.ManagementResponsibilityOwners).ThenInclude(f => f.Document)
            .Where(r => r.ManagementResponsibilityId == managementResponsibilityId)
            .FirstOrDefaultAsync();
    }
}