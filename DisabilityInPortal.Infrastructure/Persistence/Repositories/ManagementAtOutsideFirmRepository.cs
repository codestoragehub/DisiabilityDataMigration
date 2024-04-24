using System.Linq;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisabilityInPortal.Infrastructure.Persistence.Repositories;

public class ManagementAtOutsideFirmRepository : IManagementAtOutsideFirmRepository
{
    private readonly IRepositoryAsync<ManagementAtOutsideFirm> _repository;

    public ManagementAtOutsideFirmRepository(IRepositoryAsync<ManagementAtOutsideFirm> repository)
    {
        _repository = repository;
    }

    public async Task<ManagementAtOutsideFirm> GetManagementAtOutsideFirmByIdAsync(int managementAtOutsideFirmId)
    {
        return await _repository.Entities
            .Include(r => r.OutsideFirmIndividuals)
            .Where(r => r.ManagementAtOutsideFirmId == managementAtOutsideFirmId)
            .FirstOrDefaultAsync();
    }
}