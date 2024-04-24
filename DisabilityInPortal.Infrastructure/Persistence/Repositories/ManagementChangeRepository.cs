using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementChangeRepository : IManagementChangeRepository
{
    private readonly IRepositoryAsync<ManagementChange> _repository;

    public ManagementChangeRepository(IRepositoryAsync<ManagementChange> repository)
    {
        _repository = repository;
    }

    public Task<ManagementChange> GetManagementChangeByIdAsync(int managementChangeId)
    {
        return _repository.Entities
            .Include(r => r.ManagementChangeAgreements).ThenInclude(f => f.Document)
            .Where(r => r.ManagementChangeId == managementChangeId)
            .FirstOrDefaultAsync();
    }
}